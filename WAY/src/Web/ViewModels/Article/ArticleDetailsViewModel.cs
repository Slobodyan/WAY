using System.Collections.Generic;

namespace Web.ViewModels {
	public class ArticleDetailsViewModel : BaseDetailsViewModel<ArticleDetailViewModel> {

		public ICollection<CommentViewModel> Comments { get; set; } 
	}
}
