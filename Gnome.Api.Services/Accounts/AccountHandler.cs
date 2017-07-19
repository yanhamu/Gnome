using Gnome.Api.Services.Accounts.Requests;
using Gnome.Core.DataAccess;
using MediatR;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Api.Services.Accounts
{
    public class AccountHandler :
        IRequestHandler<ListUserAccounts, List<Account>>,
        IRequestHandler<GetAccount, Account>,
        IRequestHandler<UpdateAccount, Account>,
        IRequestHandler<CreateAccount, Account>
    {
        private readonly FioAccountRepository repository;

        public AccountHandler(FioAccountRepository repository)
        {
            this.repository = repository;
        }

        public List<Account> Handle(ListUserAccounts message)
        {
            return repository
                .GetAccounts(message.UserId)
                .Select(a => new Account(a.Id, a.Name, a.Token))
                .ToList();
        }

        public Account Handle(GetAccount message)
        {
            var account = repository.Get(message.AccountId);
            return new Account(account.Id, account.Name, account.Token);
        }

        public Account Handle(UpdateAccount message)
        {
            var updated = repository.Update(message.Id, message.Name, message.Token);
            return new Account(updated.Id, updated.Name, updated.Token);
        }

        public Account Handle(CreateAccount message)
        {
            var created = repository.Create(new Core.Model.FioAccount(0, message.UserId, message.Name, message.Token));
            return new Account(created.Id, created.Name, created.Token);
        }
    }
}
