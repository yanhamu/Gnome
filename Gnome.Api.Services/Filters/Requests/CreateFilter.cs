using MediatR;
using System;

namespace Gnome.Api.Services.Filters.Requests
{
    public class CreateFilter : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Expression { get; set; }
    }
}
