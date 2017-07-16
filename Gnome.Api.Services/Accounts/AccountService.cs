using Gnome.Core.DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Api.Services.Accounts
{
    public class AccountService
    {
        private readonly FioAccountRepository repository;

        public AccountService(FioAccountRepository repository)
        {
            this.repository = repository;
        }

        public List<Account> List(int userId)
        {
            return repository
                .GetAccounts(userId)
                .Select(a => new Account(a.Id, a.Name, a.Token))
                .ToList();
        }

        public Account Get(int accountId)
        {
            var account = repository.Get(accountId);
            return new Account(account.Id, account.Name, account.Token);
        }

        public Account Update(Account account)
        {
            var updated = repository.Update(account.Id, account.Name, account.Token);
            return new Account(updated.Id, updated.Name, updated.Token);
        }

        public Account Create(Account account, int userId)
        {
            var created = repository.Create(new Core.Model.FioAccount(0, userId, account.Name, account.Token));
            return new Account(created.Id, created.Name, created.Token);
        }
    }
}
