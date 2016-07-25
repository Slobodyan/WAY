using System.Net;
using Microsoft.AspNet.Mvc;
using Web.ViewModels;

namespace Web.Controllers {
	public class BaseController : Controller {
		public IActionResult RedirectToHome() {
			return RedirectToAction(nameof(HomeController.Index), "Home");
		}

		public IActionResult ErrorResult() {
			Response.StatusCode = (int)HttpStatusCode.InternalServerError;
			return View("Error");
		}

		public IActionResult ForbiddenResult() {
			Response.StatusCode = (int)HttpStatusCode.Forbidden;
			return View("Error");
		}

		protected void InitBaseFilterViewModel(BaseFilterViewModel viewModel) {
			if (viewModel.Skip == null) {
				viewModel.Skip = 0;
			}
			if(viewModel.Take == null) {
				viewModel.Take = 10;
			}
		}
	}
}
