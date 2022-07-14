using _0_Framework.Application;
using _0_Framwork.Infrastructure;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Reflection;

namespace ServiceHost
{
    public class SecurityPageFilter : IPageFilter
    {
        private readonly IAuthHelper _authHelper;

        public SecurityPageFilter(IAuthHelper authHelper)
        {
            _authHelper = authHelper;
        }

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
   
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            var handlerPermission =(NeedsPermissionAttribute) context.HandlerMethod.MethodInfo.
                GetCustomAttributes(typeof(NeedsPermissionAttribute));

            if (handlerPermission == null) return;

            //if (!context.HttpContext.User.Identity.IsAuthenticated)
            //    context.HttpContext.Response.Redirect("/Login");

            var accountPermissions = _authHelper.GetPermissions();
            if (accountPermissions.All(x=>x != handlerPermission.Permission))
            context.HttpContext.Response.Redirect("/Account");




        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
          
        }
    }
}
