using System;

namespace Web.Models {
	public partial class User {
		public int Id { get; set; }
		public DateTime? BirthDate { get; set; }
		public int BloggerId { get; set; }
		public string FirstName { get; set; }
		public int? GenderId { get; set; }
		public bool HasPhoto { get; set; }
		public string LastName { get; set; }
		public string MiddleName { get; set; }
		public string Mobile { get; set; }
		public string ParentName { get; set; }
		public string Phone { get; set; }
		public string Skype { get; set; }

		public virtual Blogger Blogger { get; set; }
		public virtual DomainValue Gender { get; set; }
	}
}
