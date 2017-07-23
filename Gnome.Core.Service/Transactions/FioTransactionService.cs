using Gnome.Core.DataAccess;
using Gnome.Core.Model;
using Gnome.Core.Service.Transactions.TransactionFactories;

namespace Gnome.Core.Service.Transactions
{
    public interface IFioTransactionService
    {
        Transaction SaveFioTransaction(FioTransaction fioTransaction);
    }

    public class FioTransactionService : IFioTransactionService
    {
        private readonly ITransactionFactory<FioTransaction> fioTransactionFactory;
        private readonly ITransactionRepository repository;

        public FioTransactionService(
            ITransactionFactory<FioTransaction> fioTransactionFactory,
            ITransactionRepository transactionRepository)
        {
            this.fioTransactionFactory = fioTransactionFactory;
            this.repository = transactionRepository;
        }
        public Transaction SaveFioTransaction(FioTransaction fioTransaction)
        {
            var transaction = fioTransactionFactory.Create(fioTransaction);
            var saved = repository.Create(transaction);
            repository.Save();
            return saved;
        }
    }
}
