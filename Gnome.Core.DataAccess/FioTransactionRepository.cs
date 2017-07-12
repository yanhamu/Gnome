using Gnome.Core.Model;
using System;
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

        public List<FioTransaction> Retrieve(List<int> accountIds, DateTime from, DateTime to)
        {
            return context
                .FioTransactions
                .Where(f => accountIds.Contains(f.AccountId))
                .Where(f => f.Date >= from)
                .Where(f => f.Date <= to)
                .OrderByDescending(f => f.Date)
                .ToList();
        }

        public List<FioTransaction> Retrieve(int accountId, int limit)
        {
            return context
                .FioTransactions
                .Where(f => f.AccountId == accountId)
                .OrderByDescending(t=>t.Date)
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