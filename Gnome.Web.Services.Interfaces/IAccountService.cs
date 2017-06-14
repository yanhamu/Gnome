using Gnome.Web.Model.ViewModel;
using System.Collections.Generic;

namespace Gnome.Web.Services.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAccounts(int userId);
        Account Get(int id);
        Account Update(int accountId, Account account);
        Account CreateNew(Account account);
        Account Remove(int id);
    }
}
