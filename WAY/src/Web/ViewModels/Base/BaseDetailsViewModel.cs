namespace Web.ViewModels {
	public class BaseDetailsViewModel<TDetailViewModel>
		where TDetailViewModel : BaseDetailViewModel {

		public TDetailViewModel Detail { get; set; }
	}
}
