using Gnome.Api.Services.Transactions.Requests;
using Gnome.Core.DataAccess;
using Gnome.Core.Service.Rules;
using Gnome.Core.Service.Rules.Actions;
using MediatR.Pipeline;
using System.Threading.Tasks;

namespace Gnome.Api.Services.Transactions
{
    public class PostCreateTransactionProcessor<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse> where TRequest : CreateTransaction
    {
        private readonly IRulesEvaluator rulesEvaluator;
        private readonly IAccountRepository accountRepository;
        private readonly IActionFactory actionFactory;

        public PostCreateTransactionProcessor(
            IRulesEvaluator rulesEvaluator,
            IAccountRepository accountRepository,
            IActionFactory actionFactory)
        {
            this.rulesEvaluator = rulesEvaluator;
            this.accountRepository = accountRepository;
            this.actionFactory = actionFactory;
        }

        public async Task Process(TRequest message, TResponse response)
        {
            var userId = (await accountRepository.Find(message.AccountId)).UserId;
            (await rulesEvaluator
                .GetSuitableRules(message.Id, userId))
                .ForEach(r => actionFactory.Create(r, message.Id));
        }
    }
}