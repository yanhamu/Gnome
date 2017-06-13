using Gnome.Web.Model.ViewModel;
using System.Collections.Generic;

namespace Gnome.Web.Services.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAccounts(int userId);
    }
}
