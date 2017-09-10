using Gnome.Api.Services.Filters.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Gnome.Api.Controllers
{
    [Route("api/filter")]
    public class FilterController : IUserAuthenticatedController
    {
        private readonly IMediator mediator;

        public Guid UserId { get; set; }

        public FilterController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{filterId:Guid}")]
        public async Task<IActionResult> Get(Guid filterId)
        {
            return new OkObjectResult(await mediator.Send(new GetFilter(filterId)));
        }
    }
}