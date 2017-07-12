using Gnome.Web.Model;
using Gnome.Web.Model.Reports;
using System;
using System.Collections.Generic;

namespace Gnome.Web.Services
{
    public class AggregateReportService
    {
        public AggregateReport CreateReport(int userId, Interval interval)
        {
            var report = new AggregateReport();

            report.Requested = interval;
            report.Aggregates = GetAggregates(userId, interval);

            return report;
        }

        private List<Aggregate> GetAggregates(int userId, Interval interval)
        {
            var result = new List<Aggregate>();
            result.Add(new Aggregate() { Date = DateTime.Now, Expences = 123 });
            result.Add(new Aggregate() { Date = DateTime.Now.AddDays(-1), Expences = 13 });
            return result;
        }
    }
}
