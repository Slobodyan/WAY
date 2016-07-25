using System.Collections.Generic;

namespace Web.Models {
	public partial class DomainValueType {
		public DomainValueType() {
			DomainValues = new HashSet<DomainValue>();
		}

		public int Id { get; set; }
		public string Name { get; set; }

		public virtual ICollection<DomainValue> DomainValues { get; set; }
	}
}
