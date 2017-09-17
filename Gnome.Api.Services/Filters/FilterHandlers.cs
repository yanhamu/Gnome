using Gnome.Api.Services.Filters.Requests;
using MediatR;
using System;

namespace Gnome.Api.Services.Filters
{
    public class FilterHandlers : IRequestHandler<ListFilters, Model.Filters>
    {
        public Model.Filters Handle(ListFilters message)
        {
            throw new NotImplementedException();
        }
    }
}
