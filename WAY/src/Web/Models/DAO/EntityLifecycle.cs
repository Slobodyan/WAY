using System.Collections.Generic;

namespace Web.Models {
	public partial class EntityLifecycle {
		public EntityLifecycle() {
			EntityStates = new HashSet<EntityState>();
			EntityTransitions = new HashSet<EntityTransition>();
			EntityTypes = new HashSet<EntityType>();
		}

		public int Id { get; set; }
		public string Name { get; set; }

		public virtual ICollection<EntityState> EntityStates { get; set; }
		public virtual ICollection<EntityTransition> EntityTransitions { get; set; }
		public virtual ICollection<EntityType> EntityTypes { get; set; }
	}
}
