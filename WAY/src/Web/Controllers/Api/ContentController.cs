using Microsoft.AspNet.Mvc;
using Web.Repositories;
using Web.ViewModels;

namespace Web.Controllers.Api {
	[Route("api/content")]
	public class ContentApiController : Controller {

		private readonly IContentRepository _contentRepository;

		public ContentApiController(
			IContentRepository contentRepository
			) {
			_contentRepository = contentRepository;
		}

		[HttpPost]
		[Route("photo")]
		public IActionResult Photo([FromBody]PhotoViewModel viewModel) {
			byte[] bytes = _contentRepository.GetImage(viewModel.Guid, viewModel.Width);

			return Ok(bytes);
		}
	}
}
