using Gnome.Api.Services.Transactions.Model;
using Gnome.Api.Services.Transactions.Requests;
using Gnome.Core.DataAccess;
using Gnome.Core.Model;
using Gnome.Core.Service.Categories;
using Gnome.Core.Service.Search.Filters;
using Gnome.Core.Service.Search.QueryBuilders;
using Gnome.Core.Service.Transactions.RowFactories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Api.Services.Transactions
{
    public class SearchTransactionHandler : IRequestHandler<SingleAccountSearchTransaction, SearchTransactionResult>
    {
        private readonly ITransactionRepository repository;
        private readonly IQueryBuilderService<Transaction, SingleAccountTransactionSearchFilter> queryBuilder;
        private readonly IAbstractTransactionFactory rowFactory;
        private readonly ICategoryResolverFactory categoryResolverFactory;

        public SearchTransactionHandler(
            ITransactionRepository repository,
            IQueryBuilderService<Transaction, SingleAccountTransactionSearchFilter> queryBuilder,
            IAbstractTransactionFactory transactionRowFactory,
            ICategoryResolverFactory categoryResolverFactory)
        {
            this.repository = repository;
            this.queryBuilder = queryBuilder;
            this.rowFactory = transactionRowFactory;
            this.categoryResolverFactory = categoryResolverFactory;
        }

        public SearchTransactionResult Handle(SingleAccountSearchTransaction message)
        {
            var categoryResolver = categoryResolverFactory.Create(message.UserId, message.Filter);
            var transactionsQuery = queryBuilder.Filter(repository.Query, message.Filter);
            var rows = transactionsQuery.OrderByDescending(t => t.Date).ToList()
                .Select(t => rowFactory.Create(t))
                .Select(t => new TransactionCategoriesRow() { Row = t, Categories = categoryResolver.GetCategories(t.Id) });

            var result = new SearchTransactionResult()
            {
                Rows = rows.ToList()
            };

            return result;
        }
    }
}