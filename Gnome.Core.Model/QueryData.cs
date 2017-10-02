using System;
using System.Collections.Generic;

namespace Gnome.Core.Model
{
    public class QueryData
    {
        public QueryData(List<Guid> excludeExpressions, List<Guid> includeExpressions, List<Guid> accounts)
        {
            this.Accounts = accounts;
            this.IncludeExpressions = includeExpressions ?? new List<Guid>();
            this.ExcludeExpressions = excludeExpressions ?? new List<Guid>();
        }

        public List<Guid> Accounts { get; }
        public List<Guid> IncludeExpressions { get; }
        public List<Guid> ExcludeExpressions { get; }
    }
}
