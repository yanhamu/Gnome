using Gnome.Core.Service.Transactions;
using System.Collections.Generic;

namespace Gnome.Api.Services.Transactions.Model
{
    public class SearchTransactionResult
    {
        public SearchTransactionResult(List<TransactionCategoryRow> rows, PaginationResult paging)
        {
            this.Rows = rows;
            this.Paging = paging;
        }

        public List<TransactionCategoryRow> Rows { get; }
        public PaginationResult Paging { get; }
    }
}