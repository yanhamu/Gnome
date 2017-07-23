using Gnome.Api.Services.Transactions.Requests;
using Gnome.Core.Service.Transactions;
using MediatR;
using System;

namespace Gnome.Api.Services.Transactions
{
    public class TransactionHandler : IRequestHandler<CreateFioTransaction, Guid>
    {
        private readonly IFioTransactionService transactionService;

        public TransactionHandler(
            IFioTransactionService transactionService)
        {
            this.transactionService = transactionService;
        }

        public Guid Handle(CreateFioTransaction message)
        {
            var transaction = transactionService.SaveFioTransaction(message.Transaction);
            return transaction.Id;
        }
    }
}
