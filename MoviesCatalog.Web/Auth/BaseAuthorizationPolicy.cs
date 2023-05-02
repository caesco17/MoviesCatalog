using Microsoft.AspNetCore.Authorization;

namespace MoviesCatalog.Web.Auth
{
    public class BaseAuthorizationPolicy : IAuthorizationRequirement
    {
        public string AuthorizationPolicy;

        public BaseAuthorizationPolicy(string _AuthorizationPolicy)
        {
            AuthorizationPolicy = _AuthorizationPolicy;
        }
    }
}
