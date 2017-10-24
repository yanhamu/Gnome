using Gnome.Api.Services.Reports.Requests;
using Gnome.Core.DataAccess;
using MediatR;

namespace Gnome.Api.Services.Reports
{
    public class UpdateReportHandler : IRequestHandler<UpdateReport, Report>
    {
        private readonly IReportRepository repository;

        public UpdateReportHandler(IReportRepository repository)
        {
            this.repository = repository;
        }
        public Report Handle(UpdateReport message)
        {
            var toUpdate = repository.Find(message.Id);
            toUpdate.Name = message.Name;
            toUpdate.QueryId = message.QueryId;
            toUpdate.UserId = message.UserId;
            toUpdate.Type = message.Type;

            repository.Save();

            return new Report(toUpdate.Id, toUpdate.QueryId, toUpdate.Name, toUpdate.Type);
        }
    }
}
