using Gnome.Web.Model;
using Gnome.Web.Model.ViewModel;
using System.Collections.Generic;

namespace Gnome.Web.Services.Interfaces
{
    public interface ITransactionService
    {
        List<Transaction> GetTransactions(int accountId, TransactionFilter filter);
    }
}
