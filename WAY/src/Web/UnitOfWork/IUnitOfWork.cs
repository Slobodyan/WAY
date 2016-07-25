using System;
using Web.Models;

namespace Web.UnitOfWork {
	public interface IUnitOfWork : IDisposable {

		void SaveChanges();
		DatabaseContext DbContext { get; }
	}
}
