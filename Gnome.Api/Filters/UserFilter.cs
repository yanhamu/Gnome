using Gnome.Api.Controllers;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Reflection;

namespace Gnome.Api.Filters
{
    public class UserFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context) { }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionDescriptor is ControllerActionDescriptor action && action.MethodInfo.GetCustomAttribute<IgnoreUserFilter>() != null)
                return;

            if (context.Controller is IUserAuthenticatedController userAuthenticatedController)
                userAuthenticatedController.UserId = Guid.Parse(context.HttpContext.User.FindFirst("user_id").Value);
        }
    }
}
