using Gnome.Web.Model.ViewModel;
using Gnome.Web.Services.Interfaces;
using System.Collections.Generic;

namespace Gnome.Web.Services.Mock
{
    public class AccountService : IAccountService
    {
        public IEnumerable<Account> GetAccounts(int userId)
        {
            return new List<Account>() {
                new Account(){ Id = 1, Name = "Fio" },
                new Account(){ Id = 2, Name = "CSOB" }
            };
        }
    }
}
