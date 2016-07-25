using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels {
	public class RegisterViewModel {

		[Required]
		[DataType(DataType.EmailAddress)]
		[Display(Name = "Email")]
		public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }

		[Display(Name = "Name")]
		public string Name { get; set; }

		[Required]
		[Display(Name = "Type")]
		public int EntityTypeId { get; set; }
	}
}
