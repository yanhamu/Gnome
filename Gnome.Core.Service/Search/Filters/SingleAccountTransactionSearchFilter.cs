using System;

namespace Gnome.Core.Service.Search.Filters
{
    public class SingleAccountTransactionSearchFilter
    {
        public Interval DateFilter { get; set; }
        public Guid AccountId { get; set; }
    }
}