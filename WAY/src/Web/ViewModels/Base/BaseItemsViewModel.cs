using System.Collections.Generic;

namespace Web.ViewModels {
	public class BaseItemsViewModel<TFilterViewModel, TItemViewModel>
		where TFilterViewModel : BaseFilterViewModel
		where TItemViewModel : BaseItemViewModel {

		public ICollection<TItemViewModel> Items { get; set; }
		public TFilterViewModel Filter { get; set; }
		public int Count { get; set; }
	}
}
