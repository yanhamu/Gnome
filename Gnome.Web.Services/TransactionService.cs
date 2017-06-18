using Gnome.Web.Model;
using Gnome.Web.Model.ViewModel;
using Gnome.Web.Services.Interfaces;
using System.Collections.Generic;

namespace Gnome.Web.Services
{
    public class TransactionService : ITransactionService
    {
        public List<Transaction> GetTransactions(int accountId, TransactionFilter filter)
        {
            var transactions = new List<Transaction>();
            for (int i = 0; i < 100; i++)
            {
                transactions.Add(Create(i));
            }
            return transactions;
        }

        private Transaction Create(int id)
        {
            var fields = new Dictionary<string, string>
            {
                ["id"] = id.ToString(),
                ["currency"] = "CZK",
                ["amount"] = "123.21"
            };
            return new Transaction() { AccountId = 1, Fields = fields };
        }
    }
}
