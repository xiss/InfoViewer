using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BikeStore.Repos
{
	public interface IRepo<T>
	{
		int Add(T entity);
		int Add(List<T> entities);
		T GetOne(int? id);
		List<T> GetAll<TSortField>(Expression<Func<T, TSortField>> orderBy, bool ascending);
		List<T> GetRange<TSortField>(Expression<Func<T, TSortField>> orderBy, int skip, int take, bool ascending = true);
		int Count { get; }
		int SaveChanges();
	}
}
