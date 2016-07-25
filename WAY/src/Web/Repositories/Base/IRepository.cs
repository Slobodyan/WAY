using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Web.UnitOfWork;

namespace Web.Repositories {
	public interface IRepository {
		IQueryable<T> GetAll<T>(params Expression<Func<T, object>>[] includes) where T : class;
		IEnumerable<T> GetAllAsNoTracking<T>(params Expression<Func<T, object>>[] includes) where T : class;
		T Get<T>(int id, params Expression<Func<T, object>>[] includes) where T : class;
		T GetAsNoTracking<T>(int id, params Expression<Func<T, object>>[] includes) where T : class;
		void Create<T>(T item) where T : class;
		void Update<T>(T item) where T : class;
		void Delete<T>(int id) where T : class;
		IUnitOfWork UnitOfWork { get; }
	}
}
