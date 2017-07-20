using Gnome.Core.DataAccess;
using Gnome.Core.Model;
using Gnome.Core.Service.Interfaces;
using System.Collections.Generic;

namespace Gnome.Core.Service
{
    public class AccountService : IAccountService
    {
        private readonly FioAccountRepository repository;

        public AccountService(FioAccountRepository repository)
        {
            this.repository = repository;
        }

        public int Create(FioAccount account)
        {
            var created = repository.Create(account);
            return created.Id;
        }

        public FioAccount Get(int accountId)
        {
            return repository.Find(accountId);
        }

        public IEnumerable<FioAccount> List(int userId)
        {
            return repository.GetAccounts(userId);
        }

        public void Remove(int accountId)
        {
            repository.Remove(accountId);
        }

        public void Update(int accountId, FioAccount account)
        {
            repository.Update(accountId, account);
        }
    }
}
