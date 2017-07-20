using Gnome.Core.Model;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Core.DataAccess
{
    public class FioAccountRepository : GenericRepository<FioAccount>
    {
        public FioAccountRepository(GnomeDb context) : base(context) { }

        public IEnumerable<FioAccount> GetAccounts(int userId)
        {
            return context.Accounts.Where(a => a.UserId == userId).ToList();
        }

        public FioAccount Update(int id, string name, string token) //TODO pull up
        {
            var toUpdate = Find(id);

            toUpdate.Name = name;
            toUpdate.Token = token;

            context.SaveChanges();

            return toUpdate;
        }

        public void Update(int accountId, FioAccount account) //TODO pull up
        {
            var toUpdate = Find(accountId);

            toUpdate.Name = account.Name;
            toUpdate.Token = account.Token;

            context.SaveChanges();
        }
    }
}