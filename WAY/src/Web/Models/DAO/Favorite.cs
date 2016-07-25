using System;

namespace Web.Models {
	public partial class Favorite {
		public int Id { get; set; }
		public int BloggerId { get; set; }
		public DateTime DateTimeUtc { get; set; }
		public int EntityInfoId { get; set; }

		public virtual Blogger Blogger { get; set; }
		public virtual EntityInfo EntityInfo { get; set; }
	}
}
