using MediatR;
using System;
using System.Collections.Generic;

namespace Gnome.Api.Services.Queries.Requests
{
    public class ListQueries : IRequest<List<Model>>
    {
        public Guid UserId { get; }

        public ListQueries(Guid userId)
        {
            this.UserId = userId;
        }
    }
}
