using System.Security.Claims;
using Microsoft.AspNet.Authorization;

namespace Web.Authentication {
	public class BloggerRequirement : AuthorizationHandler<BloggerRequirement>, IAuthorizationRequirement {
		protected override void Handle(AuthorizationContext context, BloggerRequirement requirement) {
			if(!context.User.HasClaim(c => c.Type == ClaimValueTypes.Email)) {
				context.Fail();
				return;
			}
			context.Succeed(requirement);
		}
	}
}
