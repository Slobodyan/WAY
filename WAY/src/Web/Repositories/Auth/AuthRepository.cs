using Web.UnitOfWork;

namespace Web.Repositories {
	public class AuthRepository : BaseRepository, IAuthRepository {

		public AuthRepository(IUnitOfWork unitOfWork)
			: base(unitOfWork) {
		}
	}
}
