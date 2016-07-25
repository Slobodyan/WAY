using Microsoft.AspNet.Mvc;
using Web.Repositories;
using Web.ViewModels;

namespace Web.Controllers.Api {
	[Route("api/article")]
	public class ArticleApiController : Controller {

		private readonly IArticleRepository _articleRepository;

		public ArticleApiController(
			IArticleRepository articleRepository
			) {
			_articleRepository = articleRepository;
		}

		[HttpPost]
		[Route("list")]
		public IActionResult List([FromBody]ArticleFilterViewModel filter) {
			var result = _articleRepository.GetArticleItems(0, filter);

			return Ok(result);
		}

		[HttpPost]
		[Route("details")]
		public IActionResult Details([FromBody]int id) {
			var result = _articleRepository.GetArticleDetails(0, id);

			return Ok(result);
		}
	}
}
