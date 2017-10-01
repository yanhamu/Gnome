using MediatR;
using System;

namespace Gnome.Api.Services.Queries.Requests
{
    public class RemoveQuery : INotification
    {
        private Guid queryId;

        public RemoveQuery(Guid queryId)
        {
            this.queryId = queryId;
        }
    }
}
