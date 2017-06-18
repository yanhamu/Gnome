using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Gnome.Core.DataAccess
{
    public class TransactionRepository
    {
        private readonly IMongoDatabase database;

        public TransactionRepository(IMongoDatabase database)
        {
            this.database = database;
        }

        public IEnumerable<BsonDocument> Retrieve(int limit)
        {
            var collection = database.GetCollection<BsonDocument>("transactions");
            var filter = new BsonDocument();
            return collection.Find(filter).Limit(limit).ToList();
        }
    }
}
