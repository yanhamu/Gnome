using Gnome.Core.Model.Database;
using MediatR;
using System;
using System.Collections.Generic;

namespace Gnome.Api.Services.Queries.Model
{
    public class ListQueries : IRequest<List<Query>>
    {
        private Guid userId;

        public ListQueries(Guid userId)
        {
            this.userId = userId;
        }
    }
}
