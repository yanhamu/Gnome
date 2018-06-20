using Gnome.Api.Services.Reports.Requests;
using Gnome.Core.DataAccess;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Gnome.Api.Services.Reports
{
    public class UpdateReportHandler : IRequestHandler<UpdateReport, Report>
    {
        private readonly IReportRepository repository;

        public UpdateReportHandler(IReportRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Report> Handle(UpdateReport message, CancellationToken cancellationToken)
        {
            var toUpdate = await repository.Find(message.Id);
            toUpdate.Name = message.Name;
            toUpdate.QueryId = message.QueryId;
            toUpdate.UserId = message.UserId;
            toUpdate.Type = message.Type;

            await repository.Save();

            return new Report(toUpdate.Id, toUpdate.QueryId, toUpdate.Name, toUpdate.Type);
        }
    }
}
