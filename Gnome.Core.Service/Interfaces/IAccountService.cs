using Gnome.Core.Model;
using System.Collections.Generic;

namespace Gnome.Core.Service.Interfaces
{
    public interface IAccountService
    {
        int Create(FioAccount account);
        FioAccount Get(int accountId);
        IEnumerable<FioAccount> List(int userId);
        void Remove(int accountId);
        FioAccount Update(int accountId, string name, string token);
    }
}