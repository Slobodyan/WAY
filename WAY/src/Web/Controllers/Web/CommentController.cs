using System;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Web.Authentication;
using Web.ViewModels;

namespace Web.Controllers {
	[Authorize]
	public class CommentController : Controller {

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Add(CommentViewModel viewModel) {
			if(ModelState.IsValid) {
				using(var client = new HttpClient()) {
					client.BaseAddress = HttpContext.Request.Host.HasValue ? new Uri($"http://{HttpContext.Request.Host.Value}") : new Uri("http://localhost:5000");
					client.DefaultRequestHeaders.Add(BearerAuthenticationDefaults.HeaderName, User.Claims.FirstOrDefault(m => m.Type == ClaimTypes.Authentication).Value);
					var result = client.PostAsJsonAsync("/api/comment/add", viewModel).Result;
					if(result.IsSuccessStatusCode) {
						int id = result.Content.ReadAsAsync<int>().Result;
						viewModel.Id = id;
						return Json(new { success = true, model = viewModel });
					}
				}
			}

			return Json(new { success = false, message = "Error..." });
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Delete(CommentViewModel viewModel) {
			if(ModelState.IsValid) {
				using(var client = new HttpClient()) {
					client.BaseAddress = HttpContext.Request.Host.HasValue ? new Uri($"http://{HttpContext.Request.Host.Value}") : new Uri("http://localhost:5000");
					var result = client.PostAsJsonAsync("/api/comment/delete", viewModel).Result;
					if(result.IsSuccessStatusCode) {
						bool isSucsessfull = result.Content.ReadAsAsync<bool>().Result;
						return View(isSucsessfull);
					}
				}
			}

			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Update(CommentViewModel viewModel) {
			if(ModelState.IsValid) {
				using(var client = new HttpClient()) {
					client.BaseAddress = HttpContext.Request.Host.HasValue ? new Uri($"http://{HttpContext.Request.Host.Value}") : new Uri("http://localhost:5000");
					var result = client.PostAsJsonAsync("/api/comment/update", viewModel).Result;
					if(result.IsSuccessStatusCode) {
						bool isSucsessfull = result.Content.ReadAsAsync<bool>().Result;
						return View(isSucsessfull);
					}
				}
			}

			return View(viewModel);
		}
	}
}
