using BikeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BikeStore.Repos
{
	public class CustomerRepo : BaseRepo<Customer>
	{
		private int _countRange;
		public CustomerRepo(Context context) : base(context)
		{
		}

		public async override Task<List<Customer>> GetRange<TSortField>(Expression<Func<Customer, TSortField>> orderBy, Expression<Func<Customer, bool>> where, int skip, int take, bool ascending = true)
		{
			IEnumerable<Customer> query = await Task.Run(() => Context.Customers.ToList());
			if (where != null)
				query = query.Where(where.Compile());
			query = ascending ? query.OrderBy(orderBy.Compile()) : query.OrderByDescending(orderBy.Compile());
			_countRange = query.Count();
			return await Task.Run(() => query.Skip(skip).Take(take).ToList());
		}

		public override int CountRange => _countRange;

		public async Task<decimal> AmountOrdered(int customerId)
		{
			return await Task.Run(() => Context.Customers.
			Find(customerId).Orders.
			Sum(o => o.OrderItems.
			Sum(i => i.ListPrice * i.Quantity)));
		}
	}
}
