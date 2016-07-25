using Microsoft.AspNet.Http;

namespace Web.Authentication
{
	public class BearerSigningOutContext : BearerBaseContext {
		public BearerSigningOutContext(HttpContext context, BearerAuthenticationOptions options) : base(context, options) {
		}
	}
}
