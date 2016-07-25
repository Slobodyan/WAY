using System;

namespace Web.ViewModels {
	public class BaseDetailViewModel {
		public int Id { get; set; }
		public int EntityInfoId { get; set; }
		public Guid Guid { get; set; }
	}
}
