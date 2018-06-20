using Gnome.Api.Services.Reports.Requests;
using Gnome.Core.DataAccess;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Gnome.Api.Services.Reports
{
    public class RemoveReportHandler : INotificationHandler<RemoveReport>
    {
        private readonly IReportRepository repository;

        public RemoveReportHandler(IReportRepository reportRepository)
        {
            this.repository = reportRepository;
        }

        public Task Handle(RemoveReport notification, CancellationToken cancellationToken)
        {
            var report = repository.Remove(notification.ReportId);
            repository.Save();
            return Task.CompletedTask;
        }
    }
}
