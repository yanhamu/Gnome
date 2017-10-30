using Gnome.Core.Model.Database;
using System;
using System.Collections.Generic;

namespace Gnome.Core.Service.Interfaces
{
    public interface IAccountService
    {
        Account Create(Account account);
        Account Get(Guid accountId);
        IEnumerable<Account> List(Guid userId);
        void Remove(Guid accountId);
        Account Update(Guid accountId, string name, string token);
    }
}