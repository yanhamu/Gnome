using Gnome.Api.Services.Reports.Requests;
using Gnome.Core.Service.Search.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Gnome.Api.Controllers
{
    [Route("api/reports")]
    public class ReportController : IUserAuthenticatedController
    {
        private readonly IMediator mediator;
        public Guid UserId { get; set; }

        public ReportController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateReport command)
        {
            return new OkObjectResult(await mediator.Send(command));
        }

        [HttpPost("aggregate")]
        public async Task<IActionResult> AggregateReport(TransactionSearchFilter filter)
        {
            return new OkObjectResult(await mediator.Send(new GetAggregateReport(filter, UserId, 30)));
        }

        [HttpPost("cumulative")]
        public async Task<IActionResult> CumulativeReport(TransactionSearchFilter filter)
        {
            return new OkObjectResult(await mediator.Send(new GetCumulativeReport(filter, UserId)));
        }
    }
}