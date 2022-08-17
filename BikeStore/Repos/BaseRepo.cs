using BikeStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace BikeStore.Repos
{
	public class BaseRepo<T> : IRepo<T>, IDisposable where T : class
	{
		private readonly DbSet<T> _entities;
		private readonly Context _context;
		protected Context Context => _context;
		public BaseRepo() : this(new Context())
		{
		}
		public BaseRepo(Context context)
		{
			_context = context;
			_entities = context.Set<T>();
		}

		public int Add(T entity)
		{
			_entities.Add(entity);
			return SaveChanges();
		}

		public int Add(List<T> entities)
		{
			_entities.AddRange(entities);
			return SaveChanges();
		}

		public void Dispose() => _context.Dispose();

		public virtual List<T> GetAll<TSortField>(Expression<Func<T, TSortField>> orderBy, bool ascending = true)
		{
			IQueryable<T> query = ascending ? _entities.OrderBy(orderBy) : _entities.OrderByDescending(orderBy);
			return query.ToList();
		}

		public virtual List<T> GetRange<TSortField>(Expression<Func<T, TSortField>> orderBy, int skip, int take, bool ascending = true)
		{
			IQueryable<T> query = ascending ? _entities.OrderBy(orderBy) : _entities.OrderByDescending(orderBy);
			return query.Skip(skip).Take(take).ToList();
		}

		public T GetOne(int? id) => _entities.Find(id);

		public int SaveChanges()
		{
			try
			{
				return _context.SaveChanges();
			}
			catch (DbUpdateException ex)
			{
				Debug.WriteLine(ex.Message);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
			}
			return 0;
		}

		public int Count { get => _entities.Count(); }

		private string GetTableName()
		{
			return Context.Model.FindEntityType(typeof(T)).GetTableName();
		}

		public void IdentityUpdatingOn()
		{
			string table = GetTableName();
			Context.Database.OpenConnection();

			using (var cmd = Context.Database.GetDbConnection().CreateCommand())
			{
				cmd.CommandText = $"SET IDENTITY_INSERT dbo.{table} ON";
				cmd.ExecuteNonQuery();
			}
		}

		public void IdentityUpdatingOff()
		{
			string table = GetTableName();
			Context.Database.OpenConnection();

			using (var cmd = Context.Database.GetDbConnection().CreateCommand())
			{
				cmd.CommandText = $"SET IDENTITY_INSERT dbo.{table} OFF";
				cmd.ExecuteNonQuery();
			}
		}
	}
}
