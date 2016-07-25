using Web.ViewModels;

namespace Web.Repositories {
	public interface ICommentRepository : IRepository {

		int Add(CommentViewModel comment);
		bool Delete(CommentViewModel comment);
		bool Update(CommentViewModel comment);
	}
}
