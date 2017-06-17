using Gnome.Core.DataAccess;
using Gnome.Core.Model;
using Gnome.Core.Service.Interfaces;
using System.Collections.Generic;

namespace Gnome.Core.Service
{
    public class AccountService : IAccountService
    {
        private readonly AccountRepository repository;

        public AccountService(AccountRepository repository)
        {
            this.repository = repository;
        }

        public int Create(Account account)
        {
            return repository.Create(account);
        }

        public Account Get(int accountId)
        {
            return repository.Get(accountId);
        }

        public IEnumerable<Account> List(int userId)
        {
            return repository.GetAccounts(userId);
        }

        public Account Remove(int accountId)
        {
            return repository.Remove(accountId);
        }

        public Account Update(int accountId, Account account)
        {
            return repository.Update(accountId, account);
        }
    }
}
