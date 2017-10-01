using Gnome.Api.Services.Queries.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Gnome.Api.Controllers
{
    [Route("api/queries")]
    public class QueryController : IUserAuthenticatedController
    {
        private readonly IMediator mediator;

        public Guid UserId { get; set; }

        public QueryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> List()
        {
            return new OkObjectResult(await mediator.Send(new ListQueries(UserId)));
        }
    }
}
