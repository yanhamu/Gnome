using Gnome.Core.DataAccess;
using MediatR;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Api.Services.Reports.Requests
{
    public class ListReportHandler : IRequestHandler<ListReports, List<Report>>
    {
        private readonly IReportRepository repository;

        public ListReportHandler(IReportRepository repository)
        {
            this.repository = repository;
        }

        public List<Report> Handle(ListReports message)
        {
            return repository
                .Query
                .Where(r => r.UserId == message.UserId)
                .Select(r => new Report(r.Id, r.QueryId, r.Name, r.Type))
                .ToList();
        }
    }
}
