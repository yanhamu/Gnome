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

        [HttpDelete("{filterId:Guid}")]
        public async Task<IActionResult> Remove(Guid filterId)
        {
            await mediator.Send(new RemoveFilter() { FilterId = filterId });
            return new OkResult();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFilter toCreate)
        {
            var id = await mediator.Send(toCreate);
            return new OkObjectResult(id);
        }

        [HttpPut("filterId:Guid")]
        public async Task<IActionResult> Update(Guid filterId, UpdateFilter toUpdate)
        {
            await mediator.Send(toUpdate);
            return new OkResult();
        }
    }
}