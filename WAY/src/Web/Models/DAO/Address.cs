namespace Web.Models {
	public partial class Address {
		public int Id { get; set; }
		public int BloggerId { get; set; }
		public string City { get; set; }
		public int CountryId { get; set; }
		public bool IsPrimary { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public string Number { get; set; }
		public string PostalCode { get; set; }
		public string Street { get; set; }
		public string Unit { get; set; }

		public virtual Blogger Blogger { get; set; }
		public virtual DomainValue Country { get; set; }
	}
}
