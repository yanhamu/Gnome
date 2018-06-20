using Gnome.Core.Model.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gnome.Core.DataAccess
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        Task<List<Account>> GetAccounts(Guid userId);
    }

    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(GnomeDb context) : base(context) { }

        public Task<List<Account>> GetAccounts(Guid userId)
        {
            return context.Accounts.Where(a => a.UserId == userId).ToListAsync();
        }
    }
}