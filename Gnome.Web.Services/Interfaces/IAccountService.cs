using Gnome.Web.Model.ViewModel;
using System.Collections.Generic;

namespace Gnome.Web.Services.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAccounts(int userId);
        Account Get(int accountId);
        void Update(int accountId, Account account);
        int CreateNew(Account account, int userId);
        void Remove(int accountId);
    }
}
