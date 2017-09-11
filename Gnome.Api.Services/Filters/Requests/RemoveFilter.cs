using MediatR;
using System;

namespace Gnome.Api.Services.Filters.Requests
{
    public class RemoveFilter : IRequest
    {
        public Guid FilterId { get; set; }
    }
}
