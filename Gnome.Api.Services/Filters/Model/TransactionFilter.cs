using System;
using System.Collections.Generic;

namespace Gnome.Api.Services.Filters.Model
{
    public class TransactionFilter
    {
        public List<Guid> Include { get; set; }
        public List<Guid> Exclude { get; set; }
        public string Name { get; set; }
        public Guid Id { get; set; }
    }
}
