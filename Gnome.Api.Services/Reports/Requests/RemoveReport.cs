using MediatR;
using System;

namespace Gnome.Api.Services.Reports.Requests
{
    public class RemoveReport : INotification
    {
        public Guid ReportId { get; }

        public RemoveReport(Guid reportId)
        {
            this.ReportId = reportId;
        }
    }
}
