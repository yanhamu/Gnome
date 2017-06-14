using Gnome.Web.Model.ViewModel;
using Gnome.Web.Services.Interfaces;
using System.Collections.Generic;
using System;

namespace Gnome.Web.Services.Mock
{
    public class AccountService : IAccountService
    {
        public Account CreateNew(Account account)
        {
            return new Account() { Id = 1, Name = "Fio" };
        }

        public Account Get(int id)
        {
            return new Account() { Id = 1, Name = "Fio" };
        }

        public IEnumerable<Account> GetAccounts(int userId)
        {
            return new List<Account>() {
                new Account(){ Id = 1, Name = "Fio" },
                new Account(){ Id = 2, Name = "CSOB" }
            };
        }

        public Account Remove(int id)
        {
            return new Account() { Id = 1, Name = "Fio" };
        }

        public Account Update(int accountId, Account account)
        {
            return new Account() { Id = 1, Name = "Fio" };
        }
    }
}
