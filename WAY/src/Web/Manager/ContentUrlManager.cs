using System;

namespace Web.Manager {
	public class ContentUrlManager {
		public static string GetImageUrl(Guid guid, int width) {
			return BuildContentFileUrl(GetImagePath(guid, width));
		}

		private static string GetImagePath(Guid guid, int width) {
			return $"/{guid}/photo_{width}.png";
		}

		private static string BuildContentFileUrl(string path) {
			var uriBuilder = new UriBuilder();
			uriBuilder.Query = $"v={Convert.ToBase64String(Guid.NewGuid().ToByteArray())}";
			//todo get from config
			//uriBuilder.Host = "localhost:5000";
			uriBuilder.Port = 5000;
			uriBuilder.Path = path;

			return uriBuilder.ToString();
		}
	}
}
