using System;
using System.Net.Http;
using Microsoft.AspNet.Mvc;
using Web.Manager;
using Web.Models;
using Web.ViewModels;

namespace Web.Controllers {
	public class ArticleController : BaseController {

		public IActionResult List(ArticleFilterViewModel filter) {
			if(ModelState.IsValid) {
				InitBaseFilterViewModel(filter);
				using(var client = new HttpClient()) {
					client.BaseAddress = HttpContext.Request.Host.HasValue ? new Uri($"http://{HttpContext.Request.Host.Value}") : new Uri("http://localhost:5000");
					var result = client.PostAsJsonAsync("/api/article/list", filter).Result;
					if(result.IsSuccessStatusCode) {
						var viewModel = result.Content.ReadAsAsync<ArticleItemsViewModel>().Result;
						InitArticleListViewModel(viewModel);
						return View(viewModel);
					}
				}
			}

			return RedirectToHome();
		}

		public IActionResult Details(int id) {
			using(var client = new HttpClient()) {
				client.BaseAddress = HttpContext.Request.Host.HasValue ? new Uri($"http://{HttpContext.Request.Host.Value}") : new Uri("http://localhost:5000");
				var result = client.PostAsJsonAsync("/api/article/details", id).Result;
				if(result.IsSuccessStatusCode) {
					var viewModel = result.Content.ReadAsAsync<ArticleDetailsViewModel>().Result;
					InitArticleDetailsViewModel(viewModel);
					return View(viewModel);
				}
			}

			return RedirectToHome();
		}

		private void InitArticleListViewModel(ArticleItemsViewModel viewModel) {
			foreach (var articleItemViewModel in viewModel.Items) {
				if(articleItemViewModel.HasPhoto) {
					articleItemViewModel.PhotoUrl = ContentUrlManager.GetImageUrl(articleItemViewModel.Guid, Dom.ImageSize.Width900);
				}
			}
		}

		private void InitArticleDetailsViewModel(ArticleDetailsViewModel viewModel) {
			if (viewModel.Detail.HasPhoto) {
				viewModel.Detail.PhotoUrl = ContentUrlManager.GetImageUrl(viewModel.Detail.Guid, Dom.ImageSize.Width900);
			}
		}
	}
}
