﻿using Gnome.Api.Services.Reports.Requests;
using Gnome.Core.DataAccess;
using Gnome.Core.Reports;
using Gnome.Core.Service.Search.Filters;
using MediatR;
using System;

namespace Gnome.Api.Services.Reports
{
    public class GetReportRequestFactory : IGetReportRequestFactory
    {
        private readonly IReportRepository repository;

        public GetReportRequestFactory(IReportRepository reportRepository)
        {
            this.repository = reportRepository;
        }

        public IRequest<AggregateEnvelope> Create(Guid reportId, ClosedInterval dateFilter, Guid userId)
        {
            var report = repository.Find(reportId);
            switch (report.Type)
            {
                case "aggregate":
                    return new GetAggregateReport(reportId, dateFilter, userId, 30);
                case "cumulative":
                    return new GetCumulativeReport(reportId, dateFilter, userId);
                default: throw new ArgumentException();
            }
        }
    }
}
