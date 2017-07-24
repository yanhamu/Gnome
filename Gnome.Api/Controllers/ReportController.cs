using Gnome.Api.Services.Reports;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Gnome.Api.Controllers
{
    [Route("api/reports")]
    public class ReportController : BaseController
    {
        private readonly IMediator mediator;

        public ReportController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{accountId:int}")]
        public async Task<IActionResult> AggregateReport(int accountId)
        {
            var result = await mediator.Send(new GetSingleAccountAggregateReport(
                new Core.Service.Search.Filters.Interval(DateTime.UtcNow.AddMonths(-1).Date, DateTime.UtcNow.Date),
                30,
                accountId));

            return new OkObjectResult(result);
        }
    }
}
