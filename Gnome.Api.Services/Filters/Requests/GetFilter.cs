using Gnome.Core.Model;
using MediatR;
using System;

namespace Gnome.Api.Services.Filters.Requests
{
    public class GetFilter : IRequest<Filter>
    {
        public Guid FilterId { get; }

        public GetFilter(Guid filterId)
        {
            this.FilterId = filterId;
        }
    }
}
