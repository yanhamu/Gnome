using MediatR;
using System;
using System.Collections.Generic;

namespace Gnome.Api.Services.Queries.Requests
{
    public class CreateQuery : IRequest<Model>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public List<Guid> Accounts { get; set; } = new List<Guid>();
        public List<Guid> IncludeExpressions { get; set; } = new List<Guid>();
        public List<Guid> ExcludeExpressions { get; set; } = new List<Guid>();
    }
}