using System;
using System.Collections.Generic;

namespace Gnome.Core.Service.Search.Filters
{
    public class TransactionSearchFilter
    {
        public ClosedInterval DateFilter { get; }
        public List<Guid> Accounts { get; }
        public List<Guid> IncludeExpressions { get; }
        public List<Guid> ExcludeExpressions { get; }

        public TransactionSearchFilter(ClosedInterval dateFilter, List<Guid> accounts, List<Guid> includeExpresisons, List<Guid> excludeExpressions)
        {
            this.DateFilter = dateFilter;
            this.Accounts = accounts;
            this.IncludeExpressions = includeExpresisons;
            this.ExcludeExpressions = excludeExpressions;
        }
    }
}