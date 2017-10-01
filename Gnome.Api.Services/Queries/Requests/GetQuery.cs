using Gnome.Core.Model.Database;
using MediatR;
using System;

namespace Gnome.Api.Services.Queries.Requests
{
    public class GetQuery : IRequest<Model>
    {
        private Guid queryId;

        public GetQuery(Guid queryId)
        {
            this.queryId = queryId;
        }
    }
}