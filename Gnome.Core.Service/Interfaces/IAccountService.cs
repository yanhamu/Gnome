using Gnome.Core.Model;
using System;
using System.Collections.Generic;

namespace Gnome.Core.Service.Interfaces
{
    public interface IAccountService
    {
        Guid Create(FioAccount account);
        FioAccount Get(Guid accountId);
        IEnumerable<FioAccount> List(Guid userId);
        void Remove(Guid accountId);
        FioAccount Update(Guid accountId, string name, string token);
    }
}