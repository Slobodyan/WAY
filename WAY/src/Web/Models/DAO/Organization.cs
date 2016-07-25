namespace Web.Models {
	public partial class Organization {
		public int Id { get; set; }
		public int BloggerId { get; set; }
		public string Description { get; set; }
		public bool HasPhoto { get; set; }
		public string Name { get; set; }

		public virtual Blogger Blogger { get; set; }
	}
}
