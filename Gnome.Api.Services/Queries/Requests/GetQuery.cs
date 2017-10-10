using Gnome.Core.Model;
using MediatR;
using System;

namespace Gnome.Api.Services.Queries.Requests
{
    public class GetQuery : IRequest<QueryModel>
    {
        public Guid QueryId { get; }

        public GetQuery(Guid queryId)
        {
            this.QueryId = queryId;
        }
    }
}