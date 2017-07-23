using Gnome.Core.Service.Search;
using Gnome.Core.Service.Transactions;
using Gnome.Core.Service.Transactions.RowFactories;
using System.Collections.Generic;

namespace Gnome.Api.Services.Transactions
{
    public class SearchTransactionResult
    {
        public TransactionTemplate Template { get; set; }
        public List<TransactionRow> Rows { get; set; } = new List<TransactionRow>();
        public PageResult PageResult { get; set; }
    }
}