using Gnome.Api.Services.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Register([FromBody]RegisterUser user)
        {
            await mediator.Publish(user);
            return NoContent();
        }
    }
}
