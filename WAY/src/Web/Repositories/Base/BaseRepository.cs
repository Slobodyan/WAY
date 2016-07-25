using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Web.UnitOfWork;

namespace Web.Repositories {
	public class BaseRepository : IRepository {

		private readonly IUnitOfWork _unitOfWork;

		public BaseRepository(IUnitOfWork unitOfWork) {
			if(unitOfWork == null)
				throw new ArgumentNullException(nameof(unitOfWork));

			_unitOfWork = unitOfWork;
		}

		public IQueryable<T> GetAll<T>(params Expression<Func<T, object>>[] includes) where T : class {
			var items = GetQuery<T>();

			if(!(includes == null || !includes.Any())) {
				items = includes.Aggregate(items, (query, include) => query.Include(include));
			}

			return items;
		}

		public IEnumerable<T> GetAllAsNoTracking<T>(params Expression<Func<T, object>>[] includes) where T : class {
			var items = GetQuery<T>();

			if(!(includes == null || !includes.Any())) {
				items = includes.Aggregate(items, (query, include) => query.Include(include));
			}

			return items.AsNoTracking();
		}

		public T Get<T>(int id, params Expression<Func<T, object>>[] includes) where T : class {
			var items = GetQuery<T>();

			if(!(includes == null || !includes.Any())) {
				items = includes.Aggregate(items, (query, include) => query.Include(include));
			}

			return items.First(m => (int)m.GetType().GetProperty("Id").GetValue(m) == id);
		}

		public T GetAsNoTracking<T>(int id, params Expression<Func<T, object>>[] includes) where T : class {
			var items = GetQuery<T>().AsNoTracking();

			if(!(includes == null || !includes.Any())) {
				items = includes.Aggregate(items, (query, include) => query.Include(include));
			}

			return items.First(m => (int)m.GetType().GetProperty("Id").GetValue(m) == id);
		}

		public void Create<T>(T item) where T : class {
			_unitOfWork.DbContext.ChangeTracker.TrackGraph(item, e => e.Entry.State = EntityState.Added);
			_unitOfWork.DbContext.Set<T>().Add(item);
		}

		public void Update<T>(T item) where T : class {
			_unitOfWork.DbContext.Entry(item).State = EntityState.Modified;
			_unitOfWork.DbContext.Set<T>().Update(item);
		}

		public void Delete<T>(int id) where T : class {
			var t = _unitOfWork.DbContext.Set<T>().First(m => (int)m.GetType().GetProperty("Id").GetValue(m) == id);
			if(t != null)
				_unitOfWork.DbContext.Set<T>().Remove(t);
		}

		public IUnitOfWork UnitOfWork => _unitOfWork;

		protected IQueryable<T> GetQuery<T>() where T : class {
			return _unitOfWork.DbContext.Set<T>();
		}
	}
}
