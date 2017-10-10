using Gnome.Api.Services.Reports.Requests;
using Gnome.Core.DataAccess;
using Gnome.Core.Reports;
using Gnome.Core.Reports.AggregateReport;
using Gnome.Core.Service.Query;
using Gnome.Core.Service.Search.Filters;
using MediatR;
using System;

namespace Gnome.Api.Services.Reports
{
    public class AccountAggregateReportHandler : IRequestHandler<GetAggregateReport, AggregateEnvelope>
    {
        private readonly IAggregateReportService service;
        private readonly IQueryService queryService;

        public AccountAggregateReportHandler(
            IAggregateReportService service,
            IQueryService queryService)
        {
            this.service = service;
            this.queryService = queryService;
        }

        public AggregateEnvelope Handle(GetAggregateReport message)
        {
            var query = queryService.Get(message.QueryId);
            var filter = new TransactionSearchFilter()
            {
                Accounts = query.Accounts,
                DateFilter = message.DateFilter,
                ExcludeExpressions = query.ExcludeExpressions,
                IncludeExpressions = query.IncludeExpressions,
            };
            return service.CreateReport(filter, message.UserId, message.DaysPerAggregate);
        }
    }
}
