using MediatR;
using System;

namespace Gnome.Api.Services.Reports.Requests
{
    public class CreateReport : IRequest<Report>
    {
        public Guid UserId { get; set; }
        public Guid QueryId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
    }
}
