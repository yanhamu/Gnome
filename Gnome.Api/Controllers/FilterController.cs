using Gnome.Api.Services.Filters.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Gnome.Api.Controllers
{
    [Route("api/filters")]
    public class FilterController : IUserAuthenticatedController
    {
        private readonly IMediator mediator;

        public Guid UserId { get; set; }

        public FilterController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            return new OkObjectResult(await mediator.Send(new ListFilters(UserId)));
        }
    }
}
