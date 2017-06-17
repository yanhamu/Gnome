using Gnome.Web.Model.ViewModel;
using Gnome.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Web.Services
{
    public class AccountService : IAccountService
    {
        private readonly Core.Service.Interfaces.IAccountService accountService;

        public AccountService(Core.Service.Interfaces.IAccountService accountService)
        {
            this.accountService = accountService;
        }

        public int CreateNew(Account account, int userId)
        {
            var id = accountService.Create(new Core.Model.Account(account.Id, userId, account.Name, account.Token));
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

        public Account Remove(int accountId)
        {
            return CreateViewModel(accountService.Remove(accountId));
        }

        public Account Update(int accountId, Account account)
        {
            if (accountId != account.Id)
                throw new ArgumentException("inconsistend account ids", nameof(accountId));

            var newAccount = new Gnome.Core.Model.Account()
            {
                Id = accountId,
                Name = account.Name,
                Token = account.Token
            };
            var updated = accountService.Update(accountId, newAccount);
            return CreateViewModel(updated);
        }

        private Account CreateViewModel(Gnome.Core.Model.Account account)
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