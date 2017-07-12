using Gnome.Web.Extensions;
using Gnome.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Gnome.Web.Controllers
{
    public class ReportController : BaseController
    {
        private readonly AggregateReportService aggregateReportService;

        public ReportController(AggregateReportService aggregateReportService)
        {
            this.aggregateReportService = aggregateReportService;
        }

        [HttpGet, HttpPost]
        public IActionResult AggregateReport()
        {
            var from = DateTime.UtcNow.AddMonths(-1);
            var to = DateTime.UtcNow;

            var result = aggregateReportService.CreateReport(UserId, new Model.Interval(from, to));

            return View(result);
        }
    }
}
