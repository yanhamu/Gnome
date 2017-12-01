using Gnome.Api.Services.Transactions.Requests;
using Gnome.Core.DataAccess;
using Gnome.Core.Model.Database;
using Gnome.Core.Service.Rules;
using Gnome.Core.Service.Rules.Actions;
using MediatR;
using System;

namespace Gnome.Api.Services.Transactions
{
    public class ApplyRulesTransactionHandler : IRequestHandler<CreateTransaction, Guid>
    {
        private readonly IRulesEvaluator rulesEvaluator;
        private readonly IAccountRepository accountRepository;
        private readonly IActionFactory actionFactory;

        public ApplyRulesTransactionHandler(
            IRulesEvaluator rulesEvaluator,
            IAccountRepository accountRepository,
            IActionFactory actionFactory)
        {
            this.rulesEvaluator = rulesEvaluator;
            this.accountRepository = accountRepository;
            this.actionFactory = actionFactory;
        }
        public Guid Handle(CreateTransaction message)
        {
            var userId = accountRepository.Find(message.Id).UserId;
            rulesEvaluator
                .GetSuitableRules(message.Id, userId)
                .ForEach(r => actionFactory.Create(r, message.Id));

            return message.Id;
        }
    }
}
