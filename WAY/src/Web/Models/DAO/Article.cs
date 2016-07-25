using System;

namespace Web.Models {
	public partial class Article {

		public Article() {
			PublishedDateUtc = DateTime.UtcNow;
		}

		public int Id { get; set; }
		public int BloggerId { get; set; }
		public string Description { get; set; }
		public int EntityInfoId { get; set; }
		public DateTime PublishedDateUtc { get; set; }
		public string Title { get; set; }
		public int Views { get; set; }
		public bool HasPhoto { get; set; }

		public virtual Blogger Blogger { get; set; }
		public virtual EntityInfo EntityInfo { get; set; }
	}
}
