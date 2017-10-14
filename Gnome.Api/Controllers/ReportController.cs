using Gnome.Api.Services.Reports.Requests;
using Gnome.Core.Reports;
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

        [HttpGet]
        public async Task<IActionResult> List()
        {
            return new OkObjectResult(await mediator.Send(new ListReports(UserId)));
        }

        [HttpGet("{reportId:Guid}")]
        public async Task<IActionResult> Get(Guid reportId, ClosedInterval interval)
        {
            return new OkObjectResult(await mediator.Send(new GetReport() { ReportId = reportId, DateFilter = interval }));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateReport command)
        {
            command.UserId = UserId;
            return new OkObjectResult(await mediator.Send(command));
        }

        [HttpDelete("{reportId:Guid}")]
        public async Task<IActionResult> Remove(Guid reportId)
        {
            await mediator.Publish(new RemoveReport(reportId));
            return new NoContentResult();
        }

        [HttpPut("{reportId:Guid}")]
        public async Task<IActionResult> Update(Guid reportId, [FromBody]UpdateReport updateReport)
        {
            updateReport.UserId = UserId;
            return new OkObjectResult(await mediator.Send(updateReport));
        }

        [HttpPost("aggregate")]
        public async Task<IActionResult> AggregateReport([FromBody]GetReport report)
        {
            return new OkObjectResult(await mediator.Send(new GetAggregateReport(report.ReportId, report.DateFilter, UserId, 30)));
        }

        [HttpPost("cumulative")]
        public async Task<IActionResult> CumulativeReport([FromBody]GetReport report)
        {
            return new OkObjectResult(await mediator.Send(new GetCumulativeReport(report.ReportId, report.DateFilter, UserId)));
        }
    }

    public class GetReport : IRequest<AggregateEnvelope>
    {
        public Guid ReportId { get; set; }
        public ClosedInterval DateFilter { get; set; }
    }
}