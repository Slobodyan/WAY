namespace Web.Models {
	public partial class EntityTransition {
		public int Id { get; set; }
		public int? ActionAfterCode { get; set; }
		public int? ActionBeforeCode { get; set; }
		public int EntityLifecycleId { get; set; }
		public int? EntityStateFromId { get; set; }
		public int EntityStateToId { get; set; }
		public bool IsSystem { get; set; }
		public byte Order { get; set; }

		public virtual EntityLifecycle EntityLifecycle { get; set; }
		public virtual EntityState EntityStateFrom { get; set; }
		public virtual EntityState EntityStateTo { get; set; }
	}
}
