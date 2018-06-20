using Gnome.Api.Services.Transactions.Model;
using Gnome.Api.Services.Transactions.Requests;
using Gnome.Core.DataAccess;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Gnome.Api.Services.Transactions
{
    public class SearchTransactionHandlerDecorator :
        IPipelineBehavior<SearchTransaction, SearchTransactionResult>
    {
        private readonly IAccountRepository accountRepository;

        public SearchTransactionHandlerDecorator(
            IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public Task<SearchTransactionResult> Handle(SearchTransaction request, CancellationToken cancellationToken, RequestHandlerDelegate<SearchTransactionResult> next)
        {
            if (!request.Filter.Accounts.Any())
            {
                var accounts = accountRepository
                    .Query
                    .Where(a => a.UserId == request.UserId)
                    .Select(a => a.Id)
                    .ToList();

                request.Filter.Accounts.AddRange(accounts);
            }

            return next();
        }
    }
}