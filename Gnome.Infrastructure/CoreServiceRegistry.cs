using Gnome.Core.Model.Database;
using Gnome.Core.Service;
using Gnome.Core.Service.Initialization;
using Gnome.Core.Service.Search.Filters;
using Gnome.Core.Service.Search.QueryBuilders;
using Gnome.Core.Service.Search.QueryBuilders.Categories;
using Gnome.Core.Service.Search.QueryBuilders.Transactions;
using Gnome.Core.Service.Transactions.QueryBuilders;
using StructureMap;

namespace Gnome.Infrastructure
{
    public class CoreServiceRegistry : Registry
    {
        public CoreServiceRegistry()
        {
            Scan(_ =>
            {
                _.AssemblyContainingType<UserSecurityService>();
                _.Include(t => t.Name.EndsWith("Service"));
                _.Include(t => t.Name.EndsWith("Factory"));
                _.ExcludeType<ITransactionCategoryRowQueryBuilder>(); // decorated manually
                _.Include(t => t.Name.EndsWith("Builder"));
                _.Include(t => t.Name.EndsWith("Facade"));
                _.AddAllTypesOf<IQueryBuilder<TransactionSearchFilter>>();
                _.AddAllTypesOf<IInitializationService>();
                _.WithDefaultConventions();

                For<ITransactionCategoryRowQueryBuilder>().Use<TransactionCategoryRowQueryBuilder>();
                For<ITransactionCategoryRowQueryBuilder>().DecorateAllWith<ExpressionQueryBuilder>();

                For<IQueryBuilderService<Transaction, TransactionSearchFilter>>().Use<TransactionQueryBuilder>();
                For<IQueryBuilderService<CategoryTransaction, TransactionSearchFilter>>().Use<CategoryQueryBuilderService>();
            });
        }
    }
}
