using System;
using System.IO;
using Microsoft.Extensions.PlatformAbstractions;
using Web.Manager;
using Web.UnitOfWork;

namespace Web.Repositories {
	public class ContentRepository : BaseRepository, IContentRepository {

		private readonly IApplicationEnvironment _appEnvironment;

		public ContentRepository(
			IUnitOfWork unitOfWork,
			IApplicationEnvironment appEnvironment)
			: base(unitOfWork) {
			_appEnvironment = appEnvironment;
		}

		public byte[] GetImage(Guid guid, int width) {
			string path = FileManager.GetImagePath(_appEnvironment.ApplicationBasePath, guid, width);
			var bytes = File.ReadAllBytes(path);

			return bytes;
		}
	}
}
