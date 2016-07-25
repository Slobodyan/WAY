using System;
using Web.Models;

namespace Web.UnitOfWork {
	public class UnitOfWork : IUnitOfWork {

		private readonly DatabaseContext _dbContext;
		private bool _disposed;

		public UnitOfWork(DatabaseContext dbContext) {
			_dbContext = dbContext;
		}

		public void SaveChanges() {
			_dbContext.SaveChanges();
		}

		public DatabaseContext DbContext => _dbContext;

		public virtual void Dispose(bool disposing) {
			if(!_disposed) {
				if(disposing) {
					_dbContext.Dispose();
				}
				_disposed = true;
			}
		}

		public void Dispose() {
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
