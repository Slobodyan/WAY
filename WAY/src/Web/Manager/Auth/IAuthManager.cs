using Web.ViewModels;

namespace Web.Manager {
	public interface IAuthManager {
		BloggerInfo GetBlogger(string email);

		BloggerInfo RegisterBlogger(string email, string password, string name, int entityTypeId);
	}
}
