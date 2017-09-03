using Gnome.Core.DataAccess;
using Gnome.Core.Model;
using Gnome.Core.Service.Interfaces;
using System;
using System.Collections.Generic;

namespace Gnome.Core.Service
{
    public class AccountService : IAccountService
    {
        private readonly IFioAccountRepository repository;

        public AccountService(IFioAccountRepository repository)
        {
            this.repository = repository;
        }

        public Guid Create(FioAccount account)
        {
            var created = repository.Create(account);
            return created.Id;
        }

        public FioAccount Get(Guid accountId)
        {
            return repository.Find(accountId);
        }

        public IEnumerable<FioAccount> List(Guid userId)
        {
            return repository.GetAccounts(userId);
        }

        public void Remove(Guid accountId)
        {
            repository.Remove(accountId);
            repository.Save();
        }

        public FioAccount Update(Guid accountId, string name, string token)
        {
            var fioAccount = repository.Find(accountId);

            fioAccount.Name = name;
            fioAccount.Token = token;

            repository.Save();

            return fioAccount;
        }
    }
}
