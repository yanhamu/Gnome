using Gnome.Core.Service.Transactions;
using System.Collections.Generic;

namespace Gnome.Api.Services.Transactions.Model
{
    public class SearchTransactionResult
    {
        public SearchTransactionResult(List<TransactionCategoryRow> rows)
        {
            this.Rows = rows;
        }

        public List<TransactionCategoryRow> Rows { get; }
    }
}