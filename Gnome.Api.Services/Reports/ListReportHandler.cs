using Gnome.Api.Services.Reports.Requests;
using Gnome.Core.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Gnome.Api.Services.Reports
{
    public class ListReportHandler : IRequestHandler<ListReports, List<Report>>
    {
        private readonly IReportRepository repository;

        public ListReportHandler(IReportRepository repository)
        {
            this.repository = repository;
        }

        public Task<List<Report>> Handle(ListReports message, CancellationToken cancellationToken)
        {
            return repository
                .Query
                .Where(r => r.UserId == message.UserId)
                .Select(r => new Report(r.Id, r.QueryId, r.Name, r.Type))
                .ToListAsync();
        }
    }
}
