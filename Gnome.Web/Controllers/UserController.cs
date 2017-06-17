using Gnome.Web.Model.ViewModel;
using Gnome.Web.Services;
using Gnome.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Gnome.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IAuthenticationService authenticationService;

        public UserController(IUserService userService, IAuthenticationService authenticationService)
        {
            this.userService = userService;
            this.authenticationService = authenticationService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create(UserRegistration user)
        {
            try
            {
                var userId = userService.Register(user);
                var u = userService.Verify(user.Email, user.Password);
                await authenticationService.LogIn(u, this.HttpContext);
                return Redirect("/Home");
            }
            catch
            {
                return Redirect("/Home");
            }
        }
    }
}
