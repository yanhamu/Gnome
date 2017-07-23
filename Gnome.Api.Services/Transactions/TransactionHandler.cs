using Gnome.Core.DataAccess;
using Gnome.Core.Service.Transactions;
using MediatR;

namespace Gnome.Api.Services.Transactions
{
    public class TransactionHandler : IRequestHandler<CreateFioTransaction, int>
    {
        private readonly IFioTransactionRepository repository;
        private readonly IFioTransactionService transactionService;

        public TransactionHandler(
            IFioTransactionRepository fioTransactionRepository,
            IFioTransactionService transactionService)
        {
            this.repository = fioTransactionRepository;
            this.transactionService = transactionService;
        }

        public int Handle(CreateFioTransaction message)
        {
            var transaction = repository.Save(message.Transaction);
            transactionService.SaveFioTransaction(message.Transaction);
            return transaction.Id;
        }
    }
}
