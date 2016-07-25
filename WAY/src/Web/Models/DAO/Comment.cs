using System;

namespace Web.Models {
	public partial class Comment {
		public int Id { get; set; }
		public int BloggerId { get; set; }
		public string BloggerName { get; set; }
		public DateTime DateTimeUtc { get; set; }
		public int EntityInfoId { get; set; }
		public bool IsDeleted { get; set; }
		public string Message { get; set; }

		public virtual Blogger Blogger { get; set; }
		public virtual EntityInfo EntityInfo { get; set; }
	}
}
