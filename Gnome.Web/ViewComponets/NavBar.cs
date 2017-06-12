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

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await userService.Get());
        }
    }
}