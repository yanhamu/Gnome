using Gnome.Api.Services.Transactions.Requests;
using Gnome.Core.DataAccess;
using Gnome.Core.Model.Database;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gnome.Api.Services.Transactions
{
    public class CreateTransactionHandler : IRequestHandler<CreateTransaction, Guid>
    {
        private readonly ITransactionRepository transactionRepository;
        private readonly IRequestHandler<CreateTransaction, Guid> applyRulesTransactionHandler;

        public CreateTransactionHandler(
            ITransactionRepository transactionRepository,
            IRequestHandler<CreateTransaction, Guid> applyRulesTransactionHandler)
        {
            this.transactionRepository = transactionRepository;
            this.applyRulesTransactionHandler = applyRulesTransactionHandler;
        }

        public Guid Handle(CreateTransaction message)
        {
            var t = new Transaction()
            {
                Id = message.Id,
                AccountId = message.AccountId,
                Amount = message.Amount,
                Data = message.Data,
                Date = message.Date,
                Type = message.Type,
                CategoryData = JsonConvert.SerializeObject(new List<Guid>())
            };

            transactionRepository.Create(t);
            transactionRepository.Save();

            this.applyRulesTransactionHandler.Handle(message);

            return message.Id;
        }
    }
}
