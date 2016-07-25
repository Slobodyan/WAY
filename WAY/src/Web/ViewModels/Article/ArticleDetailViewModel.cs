using System;

namespace Web.ViewModels {
	public class ArticleDetailViewModel : BaseDetailViewModel {

		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime PublishedDateUtc { get; set; }
		public int Views { get; set; }
		public bool HasPhoto { get; set; }
		public string PhotoUrl { get; set; }

		public string BloggerName { get; set; }
		public int BloggerId { get; set; }
	}
}
