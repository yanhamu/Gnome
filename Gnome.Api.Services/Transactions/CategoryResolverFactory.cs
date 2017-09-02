using Gnome.Core.DataAccess;
using Gnome.Core.Model;
using Gnome.Core.Service.Categories;
using Gnome.Core.Service.Search.Filters;
using Gnome.Core.Service.Search.QueryBuilders;
using System;
using System.Linq;

namespace Gnome.Api.Services.Transactions
{
    public interface ICategoryResolverFactory
    {
        CategoriesResolver Create(Guid userId, SingleAccountTransactionSearchFilter filter);
    }

    public class CategoryResolverFactory : ICategoryResolverFactory
    {
        private readonly ICategoryTreeFactory categoryTreeFactory;
        private readonly IQueryBuilderService<CategoryTransaction, SingleAccountTransactionSearchFilter> categoryTransactionQueryBuilderService;
        private readonly ICategoryTransactionRepository categoryTransactionRepository;

        public CategoryResolverFactory(
            ICategoryTreeFactory categoryTreeFactory,
            IQueryBuilderService<CategoryTransaction, SingleAccountTransactionSearchFilter> categoryTransactionQueryBuilderService,
            ICategoryTransactionRepository categoryTransactionRepository)
        {
            this.categoryTreeFactory = categoryTreeFactory;
            this.categoryTransactionQueryBuilderService = categoryTransactionQueryBuilderService;
            this.categoryTransactionRepository = categoryTransactionRepository;
        }

        public CategoriesResolver Create(Guid userId, SingleAccountTransactionSearchFilter filter)
        {
            var categoryTree = categoryTreeFactory.Create(userId);
            var categoryTransactionsQuery = categoryTransactionQueryBuilderService.Filter(categoryTransactionRepository.Query, filter);
            var transactionCategories = categoryTransactionsQuery.ToLookup(k => k.TransactionId, v => v.CategoryId);

            return new CategoriesResolver(categoryTree, transactionCategories);
        }
    }
}
