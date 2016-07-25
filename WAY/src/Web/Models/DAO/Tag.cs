using System.Collections.Generic;

namespace Web.Models {
	public partial class Tag {
		public Tag() {
			TagEntities = new HashSet<TagEntity>();
		}

		public int Id { get; set; }
		public int Count { get; set; }
		public string Name { get; set; }

		public virtual ICollection<TagEntity> TagEntities { get; set; }
	}
}
