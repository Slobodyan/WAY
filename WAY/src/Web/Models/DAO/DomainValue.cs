using System.Collections.Generic;

namespace Web.Models {
	public partial class DomainValue {
		public DomainValue() {
			Addresses = new HashSet<Address>();
			Translations = new HashSet<Translation>();
			Users = new HashSet<User>();
		}

		public int Id { get; set; }
		public int DomailValueTypeId { get; set; }
		public bool IsActive { get; set; }
		public int? NameCode { get; set; }

		public virtual ICollection<Address> Addresses { get; set; }
		public virtual ICollection<Translation> Translations { get; set; }
		public virtual ICollection<User> Users { get; set; }
		public virtual DomainValueType DomailValueType { get; set; }
	}
}
