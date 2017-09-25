using Gnome.Core.Service.Search.Filters;
using System;
using System.Collections.Generic;

namespace Gnome.Core.Service.Transactions.QueryBuilders
{
    public interface ITransactionCategoryRowQueryBuilder
    {
        IEnumerable<TransactionCategoryRow> Query(Guid userId, SingleAccountTransactionSearchFilter filter);
    }
}
