using BikeStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BikeStore.Repos
{
	public class OrderRepo : BaseRepo<Order>
	{
		private int _countRange;
		public OrderRepo(Context context) : base(context)
		{
		}

		//Нужен для того чтобы можно было сортировать по FullName полю которое NotMapped
		public async override Task<List<Order>> GetRange<TSortField>(Expression<Func<Order, TSortField>> orderBy, Expression<Func<Order, bool>> where, int skip, int take, bool ascending = true)
		{
			IEnumerable<Order> query = await Task.Run(() => Context.Orders.ToList());
			if (where != null)
				query = query.Where(where.Compile());
			query = ascending ? query.OrderBy(orderBy.Compile()) : query.OrderByDescending(orderBy.Compile());
			_countRange = query.Count();
			return await Task.Run(() => query.Skip(skip).Take(take).ToList());
		}

		public override int CountRange => _countRange;

		public async Task<List<(Store, decimal)>> GetSalesByStores()
		{
			var result = Task.Run(() => Context.Orders.Include(o => o.OrderItems).Include(o => o.Store).ToList().
			GroupBy(o => o.Store, o => o.OrderItems).
			Select(s => (s.Key, s.
			Sum(oi => oi.
			Sum(oi => oi.Quantity * oi.ListPrice)))).
			ToList());

			//TODO Как реализовать то  что выше так чтобы вычислать все на уровне БД? Вариант ниже не работает.
			//var b = s.GroupBy(o => o.StoreId, (sId, order) => new { id = sId, sum = order.Sum(o => o.OrderItems.GroupBy(oi => oi.OrderId, (oi, i) => i.Sum(oi => oi.ListPrice))) });

			return await result;
		}

		public async Task<List<(int, decimal)>> GetSalesByMonths()
		{
			var result = Task.Run(() => Context.Orders.Include(o => o.OrderItems).ToList().
			GroupBy(o => o.OrderDate.Month, o => o.OrderItems).
			Select(s => (s.Key, s.
			Sum(oi => oi.
			Sum(oi => oi.Quantity * oi.ListPrice)))).
			ToList());
			return await result;
		}

		public async Task<List<(Brand, decimal)>> GetSalesByBrand()
		{
			var result = Task.Run(() => Context.OrderItems.Include(oi => oi.Product).ThenInclude(p => p.Brand).ToList().
			GroupBy(oi => oi.Product.Brand, oi => oi).
			Select(s => (s.Key, s.Sum(oi => oi.ListPrice * oi.Quantity))).
			ToList());
			return await result;
		}
	}
}
