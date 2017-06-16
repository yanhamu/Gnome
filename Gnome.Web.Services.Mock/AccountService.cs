using Gnome.Web.Model.ViewModel;
using Gnome.Web.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Web.Services.Mock
{
    public class AccountService : IAccountService
    {
        private static List<Account> accountsData = new List<Account>() {
            new Account(){ Id = 1, Name = "Fio" },
            new Account(){ Id = 2, Name = "CSOB" }
        };

        public Account CreateNew(Account account)
        {
            accountsData.Add(account);
            return account;
        }

        public Account Get(int id)
        {
            return accountsData.Single(a => a.Id == id);
        }

        public IEnumerable<Account> GetAccounts(int userId)
        {
            return accountsData;
        }

        public Account Remove(int id)
        {
            var toRemove = accountsData.Single(a => a.Id == id);
            accountsData.Remove(toRemove);
            return toRemove;
        }

        public Account Update(int accountId, Account account)
        {
            var a = Get(accountId);
            a.Name = account.Name;
            a.Token = account.Token;
            return a;
        }
    }
}
