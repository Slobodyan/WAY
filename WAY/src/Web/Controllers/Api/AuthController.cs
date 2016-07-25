using System;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Web.Authentication;
using System.Linq;
using Web.Manager;
using Microsoft.AspNet.Http.Authentication;
using Web.ViewModels;

namespace Web.Controllers.Api {
	[Route("api/auth")]
	public class AuthApiController : Controller {

		private readonly IAuthManager _authManager;

		public AuthApiController(
			IAuthManager authManager
			) {
			_authManager = authManager;
		}

		[HttpPost]
		public async void LogIn([FromBody]LoginViewModel viewModel) {
			if(viewModel.Email == null || viewModel.Password == null)
				throw new Exception("Incorrect email or password");

			var bloggerInfo = _authManager.GetBlogger(viewModel.Email);
			if(bloggerInfo == null || !bloggerInfo.Password.Equals(viewModel.Password))
				throw new Exception("Incorrect email or password");

			var principal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim> {
				new Claim(ClaimTypes.NameIdentifier, bloggerInfo.Id.ToString()),
				new Claim(ClaimTypes.Email, bloggerInfo.Email)
				
			}, BearerAuthenticationDefaults.AuthenticationScheme));

			var properties = new AuthenticationProperties {
				ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1)
			};

			await HttpContext.Authentication.SignInAsync(BearerAuthenticationDefaults.AuthenticationScheme, principal, properties);
		}

		[HttpDelete]
		public async void LogOut() {
			await HttpContext.Authentication.SignOutAsync(BearerAuthenticationDefaults.AuthenticationScheme);
		}

		[Route("Register")]
		[HttpPost]
		public async void Register([FromBody]RegisterViewModel viewModel) {
			if(viewModel.Email == null || viewModel.Password == null)
				throw new Exception("Incorrect email or password");

			var bloggerInfo = _authManager.RegisterBlogger(viewModel.Email, viewModel.Password, viewModel.Name, viewModel.EntityTypeId);
			if(bloggerInfo == null)
				throw new Exception("Blogger already exists");

			var principal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim> {
				new Claim(ClaimTypes.NameIdentifier, bloggerInfo.Id.ToString()),
				new Claim(ClaimTypes.Email, bloggerInfo.Email)
			}, BearerAuthenticationDefaults.AuthenticationScheme));

			var properties = new AuthenticationProperties {
				ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1)
			};

			await HttpContext.Authentication.SignInAsync(BearerAuthenticationDefaults.AuthenticationScheme, principal, properties);
		}

		[Route("Test")]
		[HttpPost]
		[Authorize]
		public string Test() {
			return User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
		}
	}
}
