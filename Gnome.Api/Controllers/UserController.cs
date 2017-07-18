using Gnome.Api.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace Gnome.Api.Controllers
{
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly UsersService userService;

        public UserController(UsersService userService)
        {
            this.userService = userService;
        }

        [HttpPost()]
        public IActionResult Register(User user)
        {
            this.userService.CreateNewUser(user);
            return NoContent();
        }
    }
}
