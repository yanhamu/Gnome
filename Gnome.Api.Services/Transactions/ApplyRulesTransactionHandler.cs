using Gnome.Api.Services.Transactions.Requests;
using Gnome.Core.DataAccess;
using Gnome.Core.Service.Rules;
using Gnome.Core.Service.Rules.Actions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

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
        public async Task<Guid> Handle(CreateTransaction message, CancellationToken cancellationToken)
        {
            var userId = (await accountRepository.Find(message.Id)).UserId;
            (await rulesEvaluator
                .GetSuitableRules(message.Id, userId))
                .ForEach(r => actionFactory.Create(r, message.Id));

            return message.Id;
        }
    }
}
