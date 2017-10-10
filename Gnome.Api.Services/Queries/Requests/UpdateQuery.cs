using MediatR;
using System;
using System.Collections.Generic;

namespace Gnome.Api.Services.Queries.Requests
{
    public class UpdateQuery : IRequest<QueryModel>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Guid> Accounts { get; set; } = new List<Guid>();
        public List<Guid> IncludeExpressions { get; set; } = new List<Guid>();
        public List<Guid> ExcludeExpressions { get; set; } = new List<Guid>();
    }
}
