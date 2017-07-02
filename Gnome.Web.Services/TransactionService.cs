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
            return transactionService.GetTransactions(accountId, 20).Select(t => CreateTransaction(t)).ToList();
        }

        private Transaction CreateTransaction(Core.Model.FlatTransaction t)
        {
            var transaction = new Transaction() { AccountId = t.AccountId };
            foreach (var field in t.Fields)
                transaction.Fields[field.Key] = field.Value;
            return transaction;
        }
    }
}
