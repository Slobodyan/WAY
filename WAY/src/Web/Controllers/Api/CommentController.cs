using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Web.Repositories;
using Web.ViewModels;

namespace Web.Controllers.Api {
	//todo ovveride autorize attribute
	[Authorize]
	[Route("api/comment")]
	public class CommentApiController : Controller {

		private readonly ICommentRepository _commentRepository;

		public CommentApiController(
			ICommentRepository commentRepository
			) {
			_commentRepository = commentRepository;
		}

		[HttpPost]
		[Route("add")]
		public IActionResult Add([FromBody]CommentViewModel viewModel) {
			int commentId = 0;
			if(ModelState.IsValid) {
				commentId = _commentRepository.Add(viewModel);
			}

			return Ok(commentId);
		}

		[HttpPost]
		[Route("delete")]
		public IActionResult Delete([FromBody]CommentViewModel viewModel) {
			bool result = false;
			if(ModelState.IsValid) {
				result = _commentRepository.Delete(viewModel);
			}

			return Ok(result);
		}

		[HttpPost]
		[Route("update")]
		public IActionResult Update([FromBody]CommentViewModel viewModel) {
			bool result = false;
			if(ModelState.IsValid) {
				result = _commentRepository.Update(viewModel);
			}

			return Ok(result);
		}
	}
}
