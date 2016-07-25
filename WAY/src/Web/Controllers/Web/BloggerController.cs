using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Web.Authentication;
using Web.ViewModels;

namespace Web.Controllers {
	public class BloggerController : BaseController {

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginViewModel viewModel) {
			if(ModelState.IsValid) {
				using(var client = new HttpClient()) {
					client.BaseAddress = HttpContext.Request.Host.HasValue ? new Uri($"http://{HttpContext.Request.Host.Value}") : new Uri("http://localhost:5000");
					var result = client.PostAsJsonAsync("/api/auth", viewModel).Result;
					if(result.IsSuccessStatusCode) {
						var bearer = result.Headers.FirstOrDefault(m => m.Key == BearerAuthenticationDefaults.AuthenticationScheme);
						if(bearer.Value?.First() != null) {
							var id = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim> {
									new Claim(ClaimTypes.Email, viewModel.Email),
									new Claim(ClaimTypes.Authentication, bearer.Value.First())
								}, "local"));
							await HttpContext.Authentication.SignInAsync(CookiesAuthenticationDefaults.AuthenticationScheme, id);
						}
						return RedirectToHome();
					}
				}
			}

			return RedirectToHome();
		}

		[Authorize]
		public async Task<IActionResult> Logoff() {
			await HttpContext.Authentication.SignOutAsync(CookiesAuthenticationDefaults.AuthenticationScheme);
			return RedirectToHome();
		}

		[HttpGet]
		[AllowAnonymous]
		public IActionResult Register() {
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(RegisterViewModel viewModel) {
			if(ModelState.IsValid) {
				using(var client = new HttpClient()) {
					client.BaseAddress = HttpContext.Request.Host.HasValue ? new Uri($"http://{HttpContext.Request.Host.Value}") : new Uri("http://localhost:5000");
					var result = client.PostAsJsonAsync("/api/auth/register", viewModel).Result;
					if(result.IsSuccessStatusCode) {
						var bearer = result.Headers.FirstOrDefault(m => m.Key == BearerAuthenticationDefaults.AuthenticationScheme);
						if(bearer.Value?.First() != null) {
							var id = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim> {
									new Claim(ClaimTypes.Email, viewModel.Email),
									new Claim(ClaimTypes.Authentication, bearer.Value.First())
								}, "local"));
							await HttpContext.Authentication.SignInAsync(CookiesAuthenticationDefaults.AuthenticationScheme, id);
						}
						return RedirectToHome();
					}
				}
			}

			return RedirectToHome();
		}
	}
}
