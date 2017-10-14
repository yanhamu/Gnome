using Gnome.Api.Services.Reports.Requests;
using Gnome.Core.DataAccess;
using MediatR;
using System;

namespace Gnome.Api.Services.Reports
{
    public class CreateReportHandler : IRequestHandler<CreateReport, Report>
    {
        private readonly IReportRepository repository;

        public CreateReportHandler(IReportRepository reportRepository)
        {
            this.repository = reportRepository;
        }

        public Report Handle(CreateReport message)
        {
            var created = repository.Create(new Core.Model.Database.Report()
            {
                Id = new Guid(),
                QueryId = message.QueryId,
                UserId = message.UserId,
                Name = message.Name,
                Type = message.Type,
            });
            repository.Save();

            return new Report(created.Id, created.QueryId, created.Name, created.Type);
        }
    }
}
