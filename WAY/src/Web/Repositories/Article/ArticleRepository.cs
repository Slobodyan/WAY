using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Web.Models;
using Web.UnitOfWork;
using Web.ViewModels;

namespace Web.Repositories {
	public class ArticleRepository : BaseRepository, IArticleRepository {

		public ArticleRepository(IUnitOfWork unitOfWork)
			: base(unitOfWork) {
		}

		public ArticleDetailsViewModel GetArticleDetails(int bloggerId, int id) {
			var article = GetAsNoTracking<Article>(id, m => m.Blogger, m => m.EntityInfo, m => m.EntityInfo.Comments);

			if(article.EntityInfo.EntityStateId == Dom.EntityType.Common.EntityState.Active) {
				return new ArticleDetailsViewModel {
					Detail = new ArticleDetailViewModel {
						BloggerId = article.BloggerId,
						BloggerName = article.Blogger.Name,
						Description = article.Description,
						EntityInfoId = article.EntityInfoId,
						Guid = article.EntityInfo.Guid,
						HasPhoto = article.HasPhoto,
						Id = article.Id,
						PublishedDateUtc = article.PublishedDateUtc,
						Title = article.Title,
						Views = article.Views
					},
					Comments = Mapper.Map<ICollection<CommentViewModel>>(article.EntityInfo.Comments.Where(c => !c.IsDeleted))
				};
			} else
				return null;
		}

		public ArticleItemsViewModel GetArticleItems(int bloggerId, ArticleFilterViewModel filter) {
			var count = GetAllAsNoTracking<Article>(m => m.EntityInfo).Count(m => m.EntityInfo.EntityStateId == Dom.EntityType.Common.EntityState.Active);
			var articles = GetAllAsNoTracking<Article>(m => m.Blogger, m => m.EntityInfo)
				.Where(m => m.EntityInfo.EntityStateId == Dom.EntityType.Common.EntityState.Active)
				.Skip(filter.Skip ?? 0)
				.Take(filter.Take ?? 0)
				.ToList();

			var result = new ArticleItemsViewModel {
				Count = count,
				Filter = filter,
				Items = new List<ArticleItemViewModel>()
			};

			foreach(var article in articles) {
				result.Items.Add(
					new ArticleItemViewModel {
						BloggerId = article.BloggerId,
						BloggerName = article.Blogger.Name,
						Description = article.Description,
						EntityInfoId = article.EntityInfoId,
						Guid = article.EntityInfo.Guid,
						HasPhoto = article.HasPhoto,
						Id = article.Id,
						PublishedDateUtc = article.PublishedDateUtc,
						Title = article.Title,
						Views = article.Views
					});
			}

			return result;
		}
	}
}
