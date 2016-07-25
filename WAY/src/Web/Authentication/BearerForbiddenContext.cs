using Microsoft.AspNet.Http;

namespace Web.Authentication {
	public class BearerForbiddenContext : BearerBaseContext {
		public BearerForbiddenContext(HttpContext context, BearerAuthenticationOptions options) : base(context, options) {
		}
	}
}
