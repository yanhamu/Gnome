using Gnome.Api.Services.Transactions.Requests;
using Gnome.Core.DataAccess;
using Gnome.Core.Model;
using Gnome.Core.Service.Transactions;
using MediatR;
using System;

namespace Gnome.Api.Services.Transactions
{
    public class TransactionHandler : IRequestHandler<CreateFioTransaction, Guid>,
        IRequestHandler<CreateTransaction, Guid>
    {
        private readonly IFioTransactionService transactionService;
        private readonly ITransactionRepository transactionRepository;

        public TransactionHandler(
            IFioTransactionService transactionService,
            ITransactionRepository transactionRepository)
        {
            this.transactionService = transactionService;
            this.transactionRepository = transactionRepository;
        }

        public Guid Handle(CreateFioTransaction message)
        {
            var transaction = transactionService.SaveFioTransaction(message.Transaction);
            return transaction.Id;
        }

        public Guid Handle(CreateTransaction message)
        {
            var id = Guid.NewGuid();
            var t = new Transaction()
            {
                Id = id,
                AccountId = message.AccountId,
                Amount = message.Amount,
                Data = message.Data,
                Date = message.Date,
                Type = message.Type
            };

            transactionRepository.Create(t);
            transactionRepository.Save();
            return id;
        }
    }
}
