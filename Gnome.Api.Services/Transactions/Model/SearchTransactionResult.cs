using Gnome.Core.Service.Search;
using Gnome.Core.Service.Transactions.RowFactories;
using System.Collections.Generic;

namespace Gnome.Api.Services.Transactions.Model
{
    public class SearchTransactionResult
    {
        public TransactionTemplate Template { get; set; }
        public List<TransactionCategoriesRow> Rows { get; set; } = new List<TransactionCategoriesRow>();
        public PageResult PageResult { get; set; }
    }
}