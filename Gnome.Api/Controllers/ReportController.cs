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
        public async Task<IActionResult> Create([FromBody]CreateReport command)
        {
            return new OkObjectResult(await mediator.Send(command));
        }

        [HttpDelete("{reportId:Guid}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            await mediator.Publish(new RemoveReport(id));
            return new NoContentResult();
        }

        [HttpPut("{reportId:Guid}")]
        public async Task<IActionResult> Update(Guid reportId, UpdateReport updateReport)
        {
            return new OkObjectResult(await mediator.Send(updateReport));
        }

        [HttpPost("aggregate")]
        public async Task<IActionResult> AggregateReport([FromBody]GetReport report)
        {
            return new OkObjectResult(await mediator.Send(new GetAggregateReport(report.QueryId, report.DateFilter, UserId, 30)));
        }

        [HttpPost("cumulative")]
        public async Task<IActionResult> CumulativeReport([FromBody]GetReport report)
        {
            return new OkObjectResult(await mediator.Send(new GetCumulativeReport(report.QueryId, report.DateFilter, UserId)));
        }
    }

    public class GetReport
    {
        public Guid QueryId { get; set; }
        public ClosedInterval DateFilter { get; set; }
    }
}