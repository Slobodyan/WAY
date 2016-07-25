namespace Web.Models {
	public partial class Translation {
		public int Id { get; set; }
		public int LanguageId { get; set; }
		public int TranslationCodeId { get; set; }
		public string Value { get; set; }

		public virtual DomainValue Language { get; set; }
		public virtual TranslationCode TranslationCode { get; set; }
	}
}
