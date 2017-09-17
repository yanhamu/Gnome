using MediatR;
using System;

namespace Gnome.Api.Services.Filters.Requests
{
    public class ListFilters : IRequest<Gnome.Core.Model.Filter>
    {
        public Guid UserId { get; }

        public ListFilters(Guid userId)
        {
            this.UserId = userId;
        }
    }
}