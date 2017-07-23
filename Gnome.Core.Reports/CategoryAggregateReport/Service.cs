using Gnome.Core.DataAccess;
using Gnome.Core.Model;
using Gnome.Core.Reports.CategoryAggregateReport.Model;
using Gnome.Core.Service.Categories;
using System;
using System.Collections.Generic;

namespace Gnome.Core.Reports.CategoryAggregateReport
{
    public class Service
    {
        private readonly IGenericRepository<CategoryTransaction> categoryTransactionRepository;
        private readonly ICategoryTreeFactory categoryTreeFactory;

        public Service(
            IGenericRepository<CategoryTransaction> categoryTransactionRepository,
            ICategoryTreeFactory categoryTreeFactory)
        {
            this.categoryTransactionRepository = categoryTransactionRepository;
            this.categoryTreeFactory = categoryTreeFactory;
        }

        public Envelope CreateReport(List<int> accountIds, Interval interval, int daysPerAggregate, int userId)
        {
            var startDate = interval.From.AddDays(-daysPerAggregate).Date;
            //var categoryTransactions = categoryTransactionRepository.Get();
            var categoryTree = categoryTreeFactory.Create(userId);
            throw new NotImplementedException();
        }
    }
}