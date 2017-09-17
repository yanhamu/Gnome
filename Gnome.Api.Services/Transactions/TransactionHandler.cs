using Gnome.Api.Services.Transactions.Requests;
using Gnome.Core.DataAccess;
using Gnome.Core.Model.Database;
using MediatR;
using System;

namespace Gnome.Api.Services.Transactions
{
    public class TransactionHandler : IRequestHandler<CreateTransaction, Guid>
    {
        private readonly ITransactionRepository transactionRepository;

        public TransactionHandler(ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
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
