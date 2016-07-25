using System;

namespace Web.Manager {
	internal static class FileManager {

		public static string GetImagePath(string appPath, Guid guid, int width) {
			return $"{appPath}/ContentData/{guid}/photo_{width}.png";
		}
	}
}
