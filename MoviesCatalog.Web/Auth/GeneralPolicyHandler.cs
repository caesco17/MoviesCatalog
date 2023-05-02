using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Security.Principal;

namespace MoviesCatalog.Web.Auth
{
    public class GeneralPolicyHandler : AuthorizationHandler<BaseAuthorizationPolicy>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, BaseAuthorizationPolicy requirement)
        {

            var principal = context.User.Identity as ClaimsIdentity;
            IPrincipal user = context.User;

            if (user == null)
            {
                context.Fail();
            }
            else
            {
                if (user.IsInRole(requirement.AuthorizationPolicy) || user.IsInRole(RoleConstant.MOVIE_ADMIN_ROLE))
                {
                    context.Succeed(requirement);
                }
                else
                {
                    context.Fail();
                }
            }
 
            return Task.CompletedTask;
        }
    }
}
