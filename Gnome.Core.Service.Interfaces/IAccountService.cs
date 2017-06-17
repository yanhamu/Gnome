using Gnome.Core.Model;
using System.Collections.Generic;

namespace Gnome.Core.Service.Interfaces
{
    public interface IAccountService
    {
        int Create(Account account);
        Account Get(int accountId);
        IEnumerable<Account> List(int userId);
        Account Remove(int accountId);
        Account Update(int accountId, Account account);
    }
}
