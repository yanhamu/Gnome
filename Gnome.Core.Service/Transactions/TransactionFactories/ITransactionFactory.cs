using Gnome.Core.Model;

namespace Gnome.Core.Service.Transactions.TransactionFactories
{
    public interface ITransactionFactory<T>
    {
        Transaction Create(T transaction);
    }
}