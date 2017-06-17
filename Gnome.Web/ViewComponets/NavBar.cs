using Gnome.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Gnome.Web.ViewComponets
{
    public class NavBar : ViewComponent
    {
        private readonly IUserService userService;

        public NavBar(IUserService userService)
        {
            this.userService = userService;
        }

        public Task<Microsoft.AspNetCore.Mvc.ViewComponents.ViewViewComponentResult> InvokeAsync()
        {
            var user = HttpContext.User;

            if (!user.Identity.IsAuthenticated)
            {
                return Task.Run(() => View(null));
            }
            else
            {
                return Task.Run(() => View((new Model.User())));
            }
        }
    }
}