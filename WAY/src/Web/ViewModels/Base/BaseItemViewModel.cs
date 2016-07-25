using System;

namespace Web.ViewModels {
	public class BaseItemViewModel {
		public int Id { get; set; }
		public int EntityInfoId { get; set; }
		public Guid Guid { get; set; }
	}
}
