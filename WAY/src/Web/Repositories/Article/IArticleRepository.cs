using Web.ViewModels;

namespace Web.Repositories {
	public interface IArticleRepository : IRepository {

		// Details
		ArticleDetailsViewModel GetArticleDetails(int bloggerId, int id);
		ArticleItemsViewModel GetArticleItems(int bloggerId, ArticleFilterViewModel filter);
	}
}
