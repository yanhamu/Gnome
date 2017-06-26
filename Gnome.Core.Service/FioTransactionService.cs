using Gnome.Core.DataAccess;
using Gnome.Core.Model;
using Gnome.Core.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Core.Service
{
    public class FioTransactionService : ITransactionService
    {
        private readonly FioTransactionRepository repository;

        public FioTransactionService(FioTransactionRepository repository)
        {
            this.repository = repository;
        }

        public List<FlatTransaction> GetTransactions(int limit)
        {
            return repository
                .Retrieve(limit)
                .Select(t => Flattern(t))
                .ToList();
        }

        private FlatTransaction Flattern(FioTransaction t)
        {
            throw new NotImplementedException();
        }
    }
}
