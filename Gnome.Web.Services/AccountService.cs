using Gnome.Web.Model.ViewModel;
using Gnome.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Web.Services
{
    public class AccountService : IAccountService
    {
        private readonly Gnome.Core.Service.Interfaces.IAccountService accountService;

        public AccountService(Core.Service.Interfaces.IAccountService accountService)
        {
            this.accountService = accountService;
        }

        public int CreateNew(Account account, int userId)
        {
            var id = accountService.Create(new Core.Model.FioAccount(account.Id, userId, account.Name, account.Token));
            return id;
        }

        public Account Get(int accountId)
        {
            var account = accountService.Get(accountId);
            return CreateViewModel(account);
        }

        public IEnumerable<Account> GetAccounts(int userId)
        {
            return accountService.List(userId).Select(a => CreateViewModel(a));
        }

        public void Remove(int accountId)
        {
            accountService.Remove(accountId);
        }

        public void Update(int accountId, Account account)
        {
            if (accountId != account.Id)
                throw new ArgumentException("inconsistend account ids", nameof(accountId));

            var newAccount = new Gnome.Core.Model.FioAccount()
            {
                Id = accountId,
                Name = account.Name,
                Token = account.Token
            };
            accountService.Update(accountId, newAccount);
        }

        private Account CreateViewModel(Gnome.Core.Model.FioAccount account)
        {
            return new Account()
            {
                Id = account.Id,
                Name = account.Name,
                Token = account.Token
            };
        }
    }
}