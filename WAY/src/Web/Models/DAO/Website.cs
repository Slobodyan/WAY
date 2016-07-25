namespace Web.Models {
	public partial class Website {
		public int Id { get; set; }
		public int BloggerId { get; set; }
		public bool IsPrimary { get; set; }
		public string Url { get; set; }

		public virtual Blogger Blogger { get; set; }
	}
}
