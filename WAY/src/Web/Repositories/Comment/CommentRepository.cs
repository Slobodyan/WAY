using System;
using Web.Models;
using Web.UnitOfWork;
using Web.ViewModels;

namespace Web.Repositories {
	public class CommentRepository : BaseRepository, ICommentRepository {

		public CommentRepository(IUnitOfWork unitOfWork)
			: base(unitOfWork) {
		}

		public int Add(CommentViewModel comment) {
			var obj = new Comment {
				EntityInfoId = comment.EntityInfoId,
				BloggerId = comment.BloggerId,
				BloggerName = comment.BloggerName,
				DateTimeUtc = DateTime.UtcNow,
				Message = comment.Message
			};

			UnitOfWork.DbContext.Add(obj);
			UnitOfWork.SaveChanges();

			return obj.Id;
		}

		public bool Delete(CommentViewModel comment) {
			var obj = Get<Comment>(comment.Id);
			if(obj.IsDeleted || obj.BloggerId != comment.BloggerId) {
				return false;
			} else {
				obj.IsDeleted = true;
				UnitOfWork.SaveChanges();
				return true;
			}
		}

		public bool Update(CommentViewModel comment) {
			var obj = Get<Comment>(comment.Id);
			if(obj.IsDeleted || obj.BloggerId != comment.BloggerId) {
				return false;
			} else {
				obj.Message = comment.Message;
				UnitOfWork.SaveChanges();
				return true;
			}
		}
	}
}
