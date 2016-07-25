using System.Collections.Generic;

namespace Web.Models {
	public partial class TranslationCode {
		public TranslationCode() {
			Translations = new HashSet<Translation>();
		}

		public int Id { get; set; }
		public string Description { get; set; }
		public string Name { get; set; }

		public virtual ICollection<Translation> Translations { get; set; }
	}
}
