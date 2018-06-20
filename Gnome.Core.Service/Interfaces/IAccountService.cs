using Gnome.Core.Model.Database;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gnome.Core.Service.Interfaces
{
    public interface IAccountService
    {
        Account Create(Account account);
        Task<Account> Get(Guid accountId);
        Task<List<Account>> List(Guid userId);
        void Remove(Guid accountId);
        Task<Account> Update(Guid accountId, string name, string token);
    }
}