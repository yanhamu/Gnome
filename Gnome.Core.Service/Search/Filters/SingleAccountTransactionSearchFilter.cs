using System;
using System.Collections.Generic;

namespace Gnome.Core.Service.Search.Filters
{
    public class SingleAccountTransactionSearchFilter
    {
        public Interval DateFilter { get; set; }
        public Guid AccountId { get; set; }
        public List<Guid> IncludeExpressions { get; set; } = new List<Guid>();
        public List<Guid> ExcludeExpressions { get; set; } = new List<Guid>();
    }
}