using MediatR;
using System;

namespace Gnome.Api.Services.Reports.Requests
{
    public class CreateReport : IRequest<object>
    {
        public Guid UserId { get; set; }
        public Guid QueryId { get; set; }
        public string ReportType { get; set; }
    }
}
