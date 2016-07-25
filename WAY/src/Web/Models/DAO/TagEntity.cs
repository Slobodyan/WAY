namespace Web.Models {
	public partial class TagEntity {
		public int Id { get; set; }
		public int EntityInfoId { get; set; }
		public int TagId { get; set; }

		public virtual EntityInfo EntityInfo { get; set; }
		public virtual Tag Tag { get; set; }
	}
}
