using System;
using System.Linq;
using Web.Models;
using Web.Repositories;
using Web.ViewModels;

namespace Web.Manager {
	public class AuthManager : IAuthManager {

		private readonly IAuthRepository _authRepository;
		private readonly ICryptographyManager _cryptographyManager;

		public AuthManager(
			IAuthRepository authRepository,
			ICryptographyManager cryptographyManager
		) {
			_authRepository = authRepository;
			_cryptographyManager = cryptographyManager;
		}

		public BloggerInfo GetBlogger(string email) {
			BloggerInfo bloggerInfo = null;
			var blogger = _authRepository.GetAllAsNoTracking<Blogger>(m => m.EntityInfo).FirstOrDefault(x => x.Email.Equals(email.ToLower(), StringComparison.CurrentCultureIgnoreCase));
			if(blogger != null) {
				bloggerInfo = new BloggerInfo {
					Id = blogger.Id,
					Email = blogger.Email,
					Password = _cryptographyManager.Unprotect(blogger.Password),
					IsActive = blogger.EntityInfo.EntityStateId == Dom.EntityType.Common.EntityState.Active
				};
			}

			return bloggerInfo;
		}

		public BloggerInfo RegisterBlogger(string email, string password, string name, int entityTypeId) {
			BloggerInfo bloggerInfo = null;

			var isExists = _authRepository.GetAll<Blogger>().Any(x => x.Email == email.ToLower());
			if(!isExists) {
				var blogger = new Blogger {
					EntityInfo = new EntityInfo {
						EntityTypeId = entityTypeId,
						EntityStateId = Dom.EntityType.Common.EntityState.Active
					},
					Email = email.ToLower(),
					Password = _cryptographyManager.Protect(password),
					Name = name
				};
				switch(entityTypeId) {
					case 2:
						var user = new User {
							Blogger = blogger
						};
						blogger.Users.Add(user);
						break;
					case 3:
						var organization = new Organization {
							Blogger = blogger
						};
						blogger.Organizations.Add(organization);
						break;
				}
				_authRepository.Create(blogger);
				_authRepository.UnitOfWork.SaveChanges();

				bloggerInfo = new BloggerInfo {
					Id = blogger.Id,
					Email = blogger.Email,
					Password = blogger.Password,
					IsActive = blogger.EntityInfo.EntityStateId == Dom.EntityType.Common.EntityState.Active
				};
			}

			return bloggerInfo;
		}
	}
}
