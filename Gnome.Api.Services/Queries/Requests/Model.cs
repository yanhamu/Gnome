using Gnome.Core.Service.Search.Filters;
using System;
using System.Collections.Generic;

namespace Gnome.Api.Services.Queries.Requests
{
    public class Model
    {
        public Guid QueryId { get; set; }
        public Interval DateFilter { get; set; }
        public List<Guid> Accounts { get; set; } = new List<Guid>();
        public List<Guid> IncludeExpressions { get; set; } = new List<Guid>();
        public List<Guid> ExcludeExpressions { get; set; } = new List<Guid>();
    }
}
