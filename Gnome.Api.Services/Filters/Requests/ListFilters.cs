using MediatR;
using System;

namespace Gnome.Api.Services.Filters.Requests
{
    public class ListFilters : IRequest<Model.Filters>
    {
        public Guid UserId { get; }

        public ListFilters(Guid userId)
        {
            this.UserId = userId;
        }
    }
}