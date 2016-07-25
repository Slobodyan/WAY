using System;
using System.Net.Http;
using Microsoft.AspNet.Mvc;
using Web.Manager;
using Web.Models;
using Web.ViewModels;

namespace Web.Controllers {
	public class HomeController : BaseController {
		public IActionResult Index() {
			using(var client = new HttpClient()) {
				client.BaseAddress = HttpContext.Request.Host.HasValue ? new Uri($"http://{HttpContext.Request.Host.Value}") : new Uri("http://localhost:5000");
				var result = client.PostAsJsonAsync("/api/article/list", new ArticleFilterViewModel {Skip = 0,Take = 10}).Result;
				if(result.IsSuccessStatusCode) {
					var viewModel = result.Content.ReadAsAsync<ArticleItemsViewModel>().Result;
					InitArticleListViewModel(viewModel);
					return View(viewModel);
				}
			}

			return View();
		}

		private void InitArticleListViewModel(ArticleItemsViewModel viewModel) {
			foreach(var articleItemViewModel in viewModel.Items) {
				if(articleItemViewModel.HasPhoto) {
					articleItemViewModel.PhotoUrl = ContentUrlManager.GetImageUrl(articleItemViewModel.Guid, Dom.ImageSize.Width800);
				}
			}
		}
	}
}
