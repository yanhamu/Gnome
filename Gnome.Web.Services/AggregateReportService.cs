using Gnome.Core.DataAccess;
using Gnome.Web.Model;
using Gnome.Web.Model.Reports;
using Gnome.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Web.Services
{
    public class AggregateReportService
    {
        private readonly FioTransactionRepository fioTransactionRepository;
        private readonly IAccountService accountService;

        public AggregateReportService(FioTransactionRepository fioTransactionRepository, IAccountService accountService)
        {
            this.fioTransactionRepository = fioTransactionRepository;
            this.accountService = accountService;
        }

        public AggregateReport CreateReport(int userId, Interval interval, int numberOfDaysToAggregate)
        {
            var report = new AggregateReport();

            report.Requested = interval;

            report.Aggregates = GetAggregates(userId, interval, numberOfDaysToAggregate);

            return report;
        }

        private List<Aggregate> GetAggregates(int userId, Interval interval, int numberOfDaysToAggregate)
        {
            var accountIds = accountService.GetAccounts(userId).Select(a => a.Id).ToList();
            var startDate = interval.From.AddDays(-numberOfDaysToAggregate).Date;
            var transactions = fioTransactionRepository.Retrieve(accountIds, startDate, interval.To);

            var groupedExpences = transactions
                .Where(t => t.Amount < 0)
                .ToLookup(k => k.Date.Date, v => v.Amount);

            var groupedSums = new Dictionary<DateTime, decimal>();
            foreach (var group in groupedExpences)
            {
                groupedSums.Add(group.Key.Date, group.Sum(g => g));
            }

            var result = new List<Aggregate>();

            for (DateTime i = interval.From; i <= interval.To; i = i.AddDays(1))
            {
                var sum = 0m;
                for (DateTime d = i; d >= i.AddDays(-numberOfDaysToAggregate); d = d.AddDays(-1))
                {
                    if (groupedSums.ContainsKey(d.Date))
                    {
                        sum += groupedSums[d.Date];
                    }
                }
                result.Add(new Aggregate() { Date = i, Expences = sum });
            }
            return result;
        }
    }
}