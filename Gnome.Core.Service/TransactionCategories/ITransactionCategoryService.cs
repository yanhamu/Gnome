using System;
using Gnome.Core.Service.Transactions;

namespace Gnome.Core.Service.TransactionCategories
{
    public interface ITransactionCategoryService
    {
        TransactionCategoryRow Get(Guid transactionId, Guid userId);
    }
}