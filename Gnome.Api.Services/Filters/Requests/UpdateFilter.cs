using MediatR;
using System;

namespace Gnome.Api.Services.Filters.Requests
{
    public class UpdateFilter : IRequest
    {
        public Guid UserId { get; set; }
        public string Expression { get; set; }
        public Guid FilterId { get; set; }
    }
}
