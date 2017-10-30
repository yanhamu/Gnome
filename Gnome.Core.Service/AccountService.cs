using Gnome.Core.DataAccess;
using Gnome.Core.Model.Database;
using Gnome.Core.Service.Interfaces;
using System;
using System.Collections.Generic;

namespace Gnome.Core.Service
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository repository;

        public AccountService(IAccountRepository repository)
        {
            this.repository = repository;
        }

        public Account Create(Account account)
        {
            var created = repository.Create(account);
            repository.Save();
            return created;
        }

        public Account Get(Guid accountId)
        {
            return repository.Find(accountId);
        }

        public IEnumerable<Account> List(Guid userId)
        {
            return repository.GetAccounts(userId);
        }

        public void Remove(Guid accountId)
        {
            repository.Remove(accountId);
            repository.Save();
        }

        public Account Update(Guid accountId, string name, string token)
        {
            var fioAccount = repository.Find(accountId);

            fioAccount.Name = name;
            fioAccount.Token = token;

            repository.Save();

            return fioAccount;
        }
    }
}
