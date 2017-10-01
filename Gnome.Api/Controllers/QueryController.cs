using Gnome.Api.Services.Queries.Requests;
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

        [HttpGet]
        public async Task<IActionResult> List()
        {
            return new OkObjectResult(await mediator.Send(new ListQueries(UserId)));
        }

        [HttpGet("{queryId:Guid}")]
        public async Task<IActionResult> Get(Guid queryId)
        {
            return new OkObjectResult(await mediator.Send(new GetQuery(queryId)));
        }

        [HttpPut("{queryId:Guid}")]
        public async Task<IActionResult> Update(Guid queryId, UpdateQuery updateQuery)
        {
            updateQuery.Id = queryId;
            return new OkObjectResult(await mediator.Send(updateQuery));
        }

        [HttpDelete("{queryId:Guid}")]
        public async Task<IActionResult> Remove(Guid queryId)
        {
            await mediator.Publish(new RemoveQuery(queryId));
            return new NoContentResult();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateQuery query)
        {
            query.UserId = UserId;
            return new OkObjectResult(await mediator.Send(query));
        }
    }
}