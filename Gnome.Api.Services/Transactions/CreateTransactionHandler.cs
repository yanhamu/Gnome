using Gnome.Api.Services.Transactions.Requests;
using Gnome.Core.DataAccess;
using Gnome.Core.Model.Database;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

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

        public async Task<Guid> Handle(CreateTransaction message, CancellationToken cancellationToken)
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
            await transactionRepository.Save();

            await this.applyRulesTransactionHandler.Handle(message, default(CancellationToken));

            return message.Id;
        }
    }
}
