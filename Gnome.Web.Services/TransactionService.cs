using Gnome.Web.Model;
using Gnome.Web.Model.ViewModel;
using Gnome.Web.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Web.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly Core.Service.Interfaces.ITransactionService transactionService;

        public TransactionService(Gnome.Core.Service.Interfaces.ITransactionService transactionService)
        {
            this.transactionService = transactionService;
        }

        public List<Transaction> GetTransactions(int accountId, TransactionFilter filter)
        {
            return transactionService.GetTransactions(accountId, 100).Select(t => CreateTransaction(t)).ToList();
        }

        private Transaction CreateTransaction(Core.Model.FlatTransaction t)
        {
            var transaction = new Transaction() { AccountId = t.AccountId };
            transaction.Fields = t
                .Fields
                .Select(f => new { key = f.Key, value = f.Value })
                .ToDictionary(k => k.key, v => v.value);

            return transaction;
        }
    }
}
