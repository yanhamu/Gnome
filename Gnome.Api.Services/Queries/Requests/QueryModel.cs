using System;
using System.Collections.Generic;

namespace Gnome.Api.Services.Queries.Requests
{
    public class QueryModel
    {
        public Guid QueryId { get; set; }
        public string Name { get; set; }
        public List<Guid> Accounts { get; set; } = new List<Guid>();
        public List<Guid> IncludeExpressions { get; set; } = new List<Guid>();
        public List<Guid> ExcludeExpressions { get; set; } = new List<Guid>();
    }
}
