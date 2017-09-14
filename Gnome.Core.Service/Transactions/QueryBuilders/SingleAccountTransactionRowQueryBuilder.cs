using Gnome.Core.DataAccess;
using Gnome.Core.Model;
using Gnome.Core.Service.Search.Filters;
using Gnome.Core.Service.Search.QueryBuilders;
using Gnome.Core.Service.Transactions.RowFactories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Core.Service.Transactions.QueryBuilders
{
    public interface ITransactionRowQueryBuilder
    {
        IEnumerable<TransactionRow> Query(Guid userId, SingleAccountTransactionSearchFilter filter);
    }

    public class SingleAccountTransactionRowQueryBuilder : ITransactionRowQueryBuilder
    {
        private readonly ITransactionRepository repository;
        private readonly IQueryBuilderService<Transaction, SingleAccountTransactionSearchFilter> queryBuilder;
        private readonly IAbstractTransactionFactory rowFactory;

        public SingleAccountTransactionRowQueryBuilder(
            ITransactionRepository repository,
            IQueryBuilderService<Transaction, SingleAccountTransactionSearchFilter> queryBuilder,
            IAbstractTransactionFactory rowFactory)
        {
            this.repository = repository;
            this.queryBuilder = queryBuilder;
            this.rowFactory = rowFactory;
        }

        public IEnumerable<TransactionRow> Query(Guid userId, SingleAccountTransactionSearchFilter filter)
        {
            var transactionsQuery = queryBuilder.Filter(repository.Query, filter);
            return transactionsQuery.OrderByDescending(t => t.Date)
                .ToList()
                .Select(t => rowFactory.Create(t));
        }
    }
}