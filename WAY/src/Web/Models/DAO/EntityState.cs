using System.Collections.Generic;

namespace Web.Models {
	public partial class EntityState {
		public EntityState() {
			EntityInfos = new HashSet<EntityInfo>();
			EntityTransitions = new HashSet<EntityTransition>();
			EntityTransitionNavigations = new HashSet<EntityTransition>();
		}

		public int Id { get; set; }
		public int EntityLifecycleId { get; set; }
		public bool IsActive { get; set; }
		public bool IsFinish { get; set; }
		public bool IsStart { get; set; }
		public bool IsSystem { get; set; }
		public int? NameCode { get; set; }
		public byte Order { get; set; }

		public virtual ICollection<EntityInfo> EntityInfos { get; set; }
		public virtual ICollection<EntityTransition> EntityTransitions { get; set; }
		public virtual ICollection<EntityTransition> EntityTransitionNavigations { get; set; }
		public virtual EntityLifecycle EntityLifecycle { get; set; }
	}
}
