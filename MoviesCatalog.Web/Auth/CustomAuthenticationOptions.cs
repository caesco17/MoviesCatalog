using Microsoft.AspNetCore.Authorization;

namespace MoviesCatalog.Web.Auth
{
    public static class CustomAuthenticationOptions
    {
        public static void CustomConfigurePolicies(AuthorizationOptions options)
        {
            options.AddPolicy(RoleConstant.MOVIE_ADMIN_ROLE, policy => policy.Requirements.Add(new BaseAuthorizationPolicy(RoleConstant.MOVIE_ADMIN_ROLE)));
            options.AddPolicy(RoleConstant.MOVIE_USER_ROLE, policy => policy.Requirements.Add(new BaseAuthorizationPolicy(RoleConstant.MOVIE_USER_ROLE)));
        }
    }
}
