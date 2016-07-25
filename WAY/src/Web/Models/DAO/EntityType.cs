using System.Collections.Generic;

namespace Web.Models {
	public partial class EntityType {
		public EntityType() {
			EntityInfos = new HashSet<EntityInfo>();
		}

		public int Id { get; set; }
		public int EntityLifecycleId { get; set; }
		public string Name { get; set; }

		public virtual ICollection<EntityInfo> EntityInfos { get; set; }
		public virtual EntityLifecycle EntityLifecycle { get; set; }
	}
}
