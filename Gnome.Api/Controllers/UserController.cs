using Gnome.Api.Services.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gnome.Api.Controllers
{
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost()]
        public IActionResult Register([FromBody]RegisterUser user)
        {
            mediator.Publish(user);
            return NoContent();
        }
    }
}
