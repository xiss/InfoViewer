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
		public async override Task< List<Order>> GetRange<TSortField>(Expression<Func<Order, TSortField>> orderBy, Expression<Func<Order, bool>> where, int skip, int take, bool ascending = true)
		{
			IEnumerable<Order> query = Context.Orders.ToList();
			if (where != null)
				query = query.Where(where.Compile());
			query = ascending ? query.OrderBy(orderBy.Compile()) : query.OrderByDescending(orderBy.Compile());
			_countRange = query.Count();
			return await Task.Run(()=> query.Skip(skip).Take(take).ToList());
		}

		public override int CountRange => _countRange;
	}
}
