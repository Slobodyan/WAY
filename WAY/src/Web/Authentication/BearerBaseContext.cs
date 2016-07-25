using Microsoft.AspNet.Authentication;
using Microsoft.AspNet.Http;

namespace Web.Authentication {
	public abstract class BearerBaseContext : BaseContext {
		public BearerAuthenticationOptions Options { get; }

		public BearerBaseContext(HttpContext context, BearerAuthenticationOptions options) : base(context) {
			Options = options;
		}
	}
}
