using MediatR;
using System;

namespace Gnome.Api.Services.Queries.Requests
{
    public class RemoveQuery : INotification
    {
        public Guid QueryId { get; set; }

        public RemoveQuery(Guid queryId)
        {
            this.QueryId = queryId;
        }
    }
}
