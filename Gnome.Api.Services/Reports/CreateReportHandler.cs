using Gnome.Api.Services.Reports.Requests;
using Gnome.Core.DataAccess;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Gnome.Api.Services.Reports
{
    public class CreateReportHandler : IRequestHandler<CreateReport, Report>
    {
        private readonly IReportRepository repository;

        public CreateReportHandler(IReportRepository reportRepository)
        {
            this.repository = reportRepository;
        }

        public async Task<Report> Handle(CreateReport message, CancellationToken cancellationToken)
        {
            var created = repository.Create(new Core.Model.Database.Report()
            {
                Id = new Guid(),
                QueryId = message.QueryId,
                UserId = message.UserId,
                Name = message.Name,
                Type = message.Type,
            });
            await repository.Save();

            return new Report(created.Id, created.QueryId, created.Name, created.Type);
        }
    }
}
