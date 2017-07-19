using Gnome.Core.Reports;
using Gnome.Web.Extensions;
using Gnome.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Gnome.Web.Controllers
{
    public class ReportController : BaseController
    {
        private readonly Core.Reports.AggregateReport.IAggregateReportService aggregateReportService;
        private readonly IAccountService accountService;

        public ReportController(Core.Reports.AggregateReport.IAggregateReportService aggregateReportService, IAccountService accountService)
        {
            this.aggregateReportService = aggregateReportService;
            this.accountService = accountService;
        }

        [HttpGet, HttpPost]
        public IActionResult AggregateReport()
        {
            var accountIds = accountService.GetAccounts(UserId).Select(a => a.Id).ToList();
            var from = DateTime.UtcNow.AddMonths(-1);
            var to = DateTime.UtcNow;
            var aggregate = 30;

            var result = aggregateReportService.CreateReport(accountIds, new Interval(from, to), aggregate);

            return View(result);
        }
    }
}