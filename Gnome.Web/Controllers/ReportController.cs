using Gnome.Features.AggregateReport;
using Gnome.Features.AggregateReport.Model;
using Gnome.Web.Extensions;
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
            var aggregate = 30;

            var result = aggregateReportService.CreateReport(UserId, new Interval(from, to), aggregate);

            return View(result);
        }
    }
}