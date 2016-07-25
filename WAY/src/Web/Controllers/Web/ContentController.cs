using System;
using System.Net.Http;
using Microsoft.AspNet.Mvc;
using Web.ViewModels;

namespace Web.Controllers {
	public class ContentController : BaseController {

		public IActionResult Photo(Guid guid, int width) {
			using(var client = new HttpClient()) {
				client.BaseAddress = HttpContext.Request.Host.HasValue ? new Uri($"http://{HttpContext.Request.Host.Value}") : new Uri("http://localhost:5000");
				var postAsJsonAsync = client.PostAsJsonAsync("/api/content/photo", new PhotoViewModel { Guid = guid, Width = width });
				var result = postAsJsonAsync.Result;
				if(result.IsSuccessStatusCode) {
					var bytes = result.Content.ReadAsAsync<byte[]>().Result;
					return File(bytes, "image/png");
				}
			}

			return Content("");
		}
	}
}
