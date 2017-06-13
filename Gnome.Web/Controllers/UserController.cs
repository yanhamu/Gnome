using Gnome.Web.Model.ViewModel;
using Gnome.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gnome.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Create(UserRegistration user)
        {
            var result = userService.Register(user);
            if (result)
            {
                return Redirect("/Home");
            }
            else
            {
                return Redirect("/Home");
            }
        }
    }
}
