using Gnome.Core.DataAccess;
using MediatR;

namespace Gnome.Api.Services.Transactions
{
    public class TransactionHandler : IRequestHandler<CreateFioTransaction, int>
    {
        private readonly FioTransactionRepository fioTransactionRepository;

        public TransactionHandler(FioTransactionRepository fioTransactionRepository)
        {
            this.fioTransactionRepository = fioTransactionRepository;
        }

        public int Handle(CreateFioTransaction message)
        {
            var transaction = fioTransactionRepository.Save(message.Transaction);
            return transaction.Id;
        }
    }
}
