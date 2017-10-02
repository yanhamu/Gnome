using MediatR;
using System;

namespace Gnome.Api.Services.Queries.Requests
{
    public class GetQuery : IRequest<Model>
    {
        public Guid QueryId { get; }

        public GetQuery(Guid queryId)
        {
            this.QueryId = queryId;
        }
    }
}