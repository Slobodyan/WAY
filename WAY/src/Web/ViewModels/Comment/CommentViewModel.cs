using System;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels {
	public class CommentViewModel {
		public int Id { get; set; }
		[Range(1, int.MaxValue)]
		[Required]
		public int EntityInfoId { get; set; }
		[Range(1, int.MaxValue)]
		[Required]
		public int BloggerId { get; set; }
		[MaxLength(256)]
		public string BloggerName { get; set; }
		public DateTime DateTimeUtc { get; set; }
		[Required]
		public string Message { get; set; }
		public bool IsDeleted { get; set; }
	}
}
