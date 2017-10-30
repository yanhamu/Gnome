using Gnome.Api.Model;
using Gnome.Api.Services.Reports;
using Gnome.Api.Services.Reports.Requests;
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
        private readonly IGetReportRequestFactory requestFactory;

        public Guid UserId { get; set; }

        public ReportController(IMediator mediator, IGetReportRequestFactory getReportRequestFactory)
        {
            this.mediator = mediator;
            this.requestFactory = getReportRequestFactory;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            return new OkObjectResult(await mediator.Send(new ListReports(UserId)));
        }

        [HttpGet("{reportId:Guid}")]
        public async Task<IActionResult> Get(Guid reportId, ClosedInterval interval)
        {
            var request = requestFactory.Create(reportId, interval.Create(), UserId);
            return new OkObjectResult(await mediator.Send(request));
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
    }

    public class GetReport
    {
        public Guid ReportId { get; set; }
        public ClosedInterval DateFilter { get; set; }
    }
}