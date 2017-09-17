using Gnome.Api.Services.Filters.Requests;
using MediatR;
using System;

namespace Gnome.Api.Services.Filters
{
    public class FilterHandlers : IRequestHandler<ListFilters, Gnome.Core.Model.Filter>
    {
        public Gnome.Core.Model.Filter Handle(ListFilters message)
        {
            throw new NotImplementedException();
        }
    }
}
