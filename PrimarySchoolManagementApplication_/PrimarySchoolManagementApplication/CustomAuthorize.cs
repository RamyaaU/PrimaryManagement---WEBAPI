using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace PrimarySchoolManagement
{
    public class CustomAuthorizeFilter : IAuthorizationFilter
    {
        private readonly string _role;

        public CustomAuthorizeFilter(string role)
        {
            _role = role;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!IsUserInRole(context.HttpContext.User, _role))
            {
                context.Result = new ForbidResult();
            }
        }

        private bool IsUserInRole(ClaimsPrincipal user, string role)
        {
            return true;
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class CustomAuthorizeAttribute : TypeFilterAttribute
    {
        public CustomAuthorizeAttribute(string role) : base(typeof(CustomAuthorizeFilter))
        {
            Arguments = new object[] { role };
        }
    }
}