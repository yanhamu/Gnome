using Gnome.Core.Reports;
using Gnome.Core.Service.Search.Filters;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Gnome.Api.Services.Reports
{
    public interface IGetReportRequestFactory
    {
        Task<IRequest<AggregateEnvelope>> Create(Guid reportId, ClosedInterval dateFilter, Guid userId);
    }
}