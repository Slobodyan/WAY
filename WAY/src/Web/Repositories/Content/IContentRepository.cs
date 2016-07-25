using System;

namespace Web.Repositories {
	public interface IContentRepository : IRepository {

		byte[] GetImage(Guid guid, int imageWidth);
	}
}
