using Gnome.Api.Services.Reports.Requests;
using Gnome.Core.DataAccess;
using Gnome.Core.Reports;
using Gnome.Core.Reports.TotalMonthly;
using Gnome.Core.Service.Query;
using Gnome.Core.Service.Search.Filters;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Gnome.Api.Services.Reports
{
    public class TotalMonthlyReportHandler : IRequestHandler<GetTotalMonthlyReport, AggregateEnvelope>
    {
        private readonly IReportRepository reportRepository;
        private readonly IQueryService queryService;
        private readonly ITotalMonthlyReportService reportService;

        public TotalMonthlyReportHandler(
            IReportRepository reportRepository,
            IQueryService queryService,
            ITotalMonthlyReportService reportService)
        {
            this.reportRepository = reportRepository;
            this.queryService = queryService;
            this.reportService = reportService;
        }

        public async Task<AggregateEnvelope> Handle(GetTotalMonthlyReport message, CancellationToken cancellationToken)
        {
            var report = await reportRepository.Find(message.ReportId);
            var query = await queryService.Get(report.QueryId);
            var filter = new TransactionSearchFilter(message.DateFilter, query.Accounts, query.IncludeExpressions, query.ExcludeExpressions);

            return await reportService.Report(filter, message.UserId);
        }
    }
}
