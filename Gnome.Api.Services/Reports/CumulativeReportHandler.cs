using Gnome.Api.Services.Reports.Requests;
using Gnome.Core.Reports;
using Gnome.Core.Reports.Cummulative;
using Gnome.Core.Service.Query;
using Gnome.Core.Service.Search.Filters;
using MediatR;

namespace Gnome.Api.Services.Reports
{
    public class CumulativeReportHandler : IRequestHandler<GetCumulativeReport, AggregateEnvelope>
    {
        private readonly ICumulativeReportService service;
        private readonly IQueryService queryService;

        public CumulativeReportHandler(
            ICumulativeReportService service,
            IQueryService queryService)
        {
            this.service = service;
            this.queryService = queryService;
        }

        public AggregateEnvelope Handle(GetCumulativeReport message)
        {
            var query = queryService.Get(message.QueryId);

            var filter = new TransactionSearchFilter()
            {
                Accounts = query.Accounts,
                DateFilter = message.DateFilter,
                ExcludeExpressions = query.ExcludeExpressions,
                IncludeExpressions = query.IncludeExpressions
            };

            return service.Report(filter, message.UserId);
        }
    }
}
