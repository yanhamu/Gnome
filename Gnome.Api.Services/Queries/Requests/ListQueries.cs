using Gnome.Core.Model.Database;
using MediatR;
using System;
using System.Collections.Generic;

namespace Gnome.Api.Services.Queries.Requests
{
    public class ListQueries : IRequest<List<Model>>
    {
        private Guid userId;

        public ListQueries(Guid userId)
        {
            this.userId = userId;
        }
    }
}
