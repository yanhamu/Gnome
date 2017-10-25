using System;
using Gnome.Core.Reports;
using Gnome.Core.Service.Search.Filters;
using MediatR;

namespace Gnome.Api.Services.Reports
{
    public interface IGetReportRequestFactory
    {
        IRequest<AggregateEnvelope> Create(Guid reportId, ClosedInterval dateFilter, Guid userId);
    }
}