using Gnome.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Core.DataAccess
{
    public interface IFioAccountRepository : IGenericRepository<FioAccount>
    {
        IEnumerable<FioAccount> GetAccounts(Guid userId);
    }

    public class FioAccountRepository : GenericRepository<FioAccount>, IFioAccountRepository
    {
        public FioAccountRepository(GnomeDb context) : base(context) { }

        public IEnumerable<FioAccount> GetAccounts(Guid userId)
        {
            return context.Accounts.Where(a => a.UserId == userId).ToList();
        }
    }
}