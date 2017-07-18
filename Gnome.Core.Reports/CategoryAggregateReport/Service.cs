using Gnome.Core.DataAccess;
using Gnome.Core.Reports.CategoryAggregateReport.Model;
using Gnome.Core.Service.Categories;
using System;
using System.Collections.Generic;

namespace Gnome.Core.Reports.CategoryAggregateReport
{
    public class Service
    {
        private readonly FioTransactionRepository fioTransactionRepository;
        private readonly CategoryTransactionRepository categoryTransactionRepository;
        private readonly CategoryTreeFactory categoryTreeFactory;

        public Service(
            FioTransactionRepository fioTransactionRepository,
            CategoryTransactionRepository categoryTransactionRepository,
            CategoryTreeFactory categoryTreeFactory)
        {
            this.fioTransactionRepository = fioTransactionRepository;
            this.categoryTransactionRepository = categoryTransactionRepository;
            this.categoryTreeFactory = categoryTreeFactory;
        }

        public Envelope CreateReport(List<int> accountIds, Interval interval, int daysPerAggregate, int userId)
        {
            var startDate = interval.From.AddDays(-daysPerAggregate).Date;
            var transactions = fioTransactionRepository.Retrieve(accountIds, startDate, interval.To);
            //var categoryTransactions = categoryTransactionRepository.Get();
            var categoryTree = categoryTreeFactory.Create(userId);
            throw new NotImplementedException();
        }
    }
}