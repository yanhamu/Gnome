using Gnome.Core.Model;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Core.DataAccess
{
    public class FioTransactionRepository
    {
        private readonly GnomeDb context;

        public FioTransactionRepository(GnomeDb context)
        {
            this.context = context;
        }

        public List<FioTransaction> Retrieve(int accountId, int limit)
        {
            return context
                .FioTransactions
                .Where(f => f.AccountId == accountId)
                .Take(limit)
                .ToList();
        }

        public FioTransaction Save(FioTransaction transaction)
        {
            context
                .FioTransactions
                .Add(transaction);
            context.SaveChanges();
            return transaction;
        }
    }
}