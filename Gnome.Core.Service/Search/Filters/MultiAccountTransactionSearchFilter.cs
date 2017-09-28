using System;
using System.Collections.Generic;

namespace Gnome.Core.Service.Search.Filters
{
    public class MultiAccountTransactionSearchFilter
    {
        public Interval DateFilter { get; set; }
        public List<Guid> Accounts { get; set; } = new List<Guid>();
        public List<Guid> IncludeExpressions { get; set; } = new List<Guid>();
        public List<Guid> ExcludeExpressions { get; set; } = new List<Guid>();
    }
}