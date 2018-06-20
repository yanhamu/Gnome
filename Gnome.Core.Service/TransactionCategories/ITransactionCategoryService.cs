using Gnome.Core.Service.Transactions;
using System;
using System.Threading.Tasks;

namespace Gnome.Core.Service.TransactionCategories
{
    public interface ITransactionCategoryService
    {
        Task<TransactionCategoryRow> Get(Guid transactionId, Guid userId);
    }
}