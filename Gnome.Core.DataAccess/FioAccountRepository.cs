using Gnome.Core.Model;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Core.DataAccess
{
    public class FioAccountRepository
    {
        private readonly GnomeDb context;

        public FioAccountRepository(GnomeDb context)
        {
            this.context = context;
        }

        public FioAccount Create(FioAccount account)
        {
            context.Accounts.Add(account);
            context.SaveChanges();

            return account;
        }

        public FioAccount Get(int accountId)
        {
            return context.Accounts.Where(a => a.Id == accountId).SingleOrDefault();
        }

        public IEnumerable<FioAccount> GetAccounts(int userId)
        {
            return context.Accounts.Where(a => a.UserId == userId).ToList();
        }

        public void Remove(int accountId)
        {
            var toRemove = this.Get(accountId);
            if (toRemove != null)
            {
                context.Accounts.Remove(toRemove);
                context.SaveChanges();
            }
        }

        public void Update(int accountId, FioAccount account)
        {
            var toUpdate = Get(accountId);

            toUpdate.Name = account.Name;
            toUpdate.Token = account.Token;

            context.SaveChanges();
        }
    }
}