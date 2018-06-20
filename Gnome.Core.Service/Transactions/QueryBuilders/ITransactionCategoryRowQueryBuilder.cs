using Gnome.Core.Service.Search.Filters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gnome.Core.Service.Transactions.QueryBuilders
{
    public interface ITransactionCategoryRowQueryBuilder
    {
        Task<IEnumerable<TransactionCategoryRow>> Query(Guid userId, TransactionSearchFilter filter);
    }
}
