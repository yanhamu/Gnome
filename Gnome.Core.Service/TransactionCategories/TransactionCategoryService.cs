using Gnome.Core.DataAccess;
using Gnome.Core.Service.Categories;
using Gnome.Core.Service.Categories.Resolvers;
using Gnome.Core.Service.Transactions;
using Gnome.Core.Service.Transactions.RowFactories;
using System;
using System.Threading.Tasks;

namespace Gnome.Core.Service.TransactionCategories
{
    public class TransactionCategoryService : ITransactionCategoryService
    {
        private readonly ITransactionRepository transactionRepository;
        private readonly IAbstractTransactionFactory transactionFactory;
        private readonly ICategoryTreeFactory categoryTreeFactory;

        public TransactionCategoryService(
            ITransactionRepository transactionRepository,
            IAbstractTransactionFactory transactionFactory,
            ICategoryTreeFactory categoryTreeFactory)
        {
            this.transactionRepository = transactionRepository;
            this.transactionFactory = transactionFactory;
            this.categoryTreeFactory = categoryTreeFactory;
        }

        public async Task<TransactionCategoryRow> Get(Guid transactionId, Guid userId)
        {
            var transaction = await transactionRepository.Find(transactionId);
            var transactionRow = transactionFactory.Create(transaction);

            var resolver = new Resolver(await categoryTreeFactory.Create(userId));

            return new TransactionCategoryRow(transactionRow, resolver.GetCategories(transactionRow.Categories));
        }
    }
}