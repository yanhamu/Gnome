using Gnome.Core.DataAccess;
using Gnome.Core.Model;
using Gnome.Core.Service.Interfaces;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Core.Service
{
    public class TransactionService : ITransactionService
    {
        private readonly TransactionRepository repository;

        public TransactionService(TransactionRepository repository)
        {
            this.repository = repository;
        }

        public List<Transaction> GetTransactions(int limit)
        {
            return repository
                .Retrieve(limit)
                .Select(t => CreateTransaction(t))
                .ToList();
        }

        private Transaction CreateTransaction(BsonDocument t)
        {
            var result = new Transaction();
            foreach (var k in t)
                result.Fields[k.Name] = k.Value.ToString();
            return result;
        }
    }
}
