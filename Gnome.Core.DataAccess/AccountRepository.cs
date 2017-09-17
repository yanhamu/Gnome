using Gnome.Core.Model.Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Core.DataAccess
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        IEnumerable<Account> GetAccounts(Guid userId);
    }

    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(GnomeDb context) : base(context) { }

        public IEnumerable<Account> GetAccounts(Guid userId)
        {
            return context.Accounts.Where(a => a.UserId == userId).ToList();
        }
    }
}