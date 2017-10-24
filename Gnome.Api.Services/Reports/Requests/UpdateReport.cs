using MediatR;
using System;

namespace Gnome.Api.Services.Reports.Requests
{
    public class UpdateReport : IRequest<Report>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid QueryId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
    }
}
