using Gnome.Api.Services.Reports.Requests;
using Gnome.Core.DataAccess;
using MediatR;

namespace Gnome.Api.Services.Reports
{
    public class RemoveReportHandler : INotificationHandler<RemoveReport>
    {
        private readonly IReportRepository repository;

        public RemoveReportHandler(IReportRepository reportRepository)
        {
            this.repository = reportRepository;
        }

        public void Handle(RemoveReport notification)
        {
            var report = repository.Remove(notification.ReportId);
            repository.Save();
        }
    }
}
