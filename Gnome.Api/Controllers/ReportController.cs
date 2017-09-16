using Gnome.Api.Services.Reports;
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

        [HttpGet("aggregate/{accountId:int}")]
        public async Task<IActionResult> AggregateReport(Guid accountId)
        {
            var result = await mediator.Send(new GetSingleAccountAggregateReport(
                new Core.Service.Search.Filters.Interval(DateTime.UtcNow.AddMonths(-1).Date, DateTime.UtcNow.Date),
                30,
                accountId));

            return new OkObjectResult(result);
        }
    }
}