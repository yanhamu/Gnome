using Gnome.Web.Model;

namespace Gnome.Web.Services.Interfaces
{
    public interface ITransactionService
    {
        object GetTransactions(int userId, TransactionFilter filter);
    }
}
