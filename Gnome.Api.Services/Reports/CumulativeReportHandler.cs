using Gnome.Api.Services.Reports.Requests;
using Gnome.Core.Reports;
using MediatR;

namespace Gnome.Api.Services.Reports
{
    public class CumulativeReportHandler : IRequestHandler<GetCumulativeReport, AggregateEnvelope>
    {
        public AggregateEnvelope Handle(GetCumulativeReport message)
        {
            throw new System.NotImplementedException();
        }
    }
}
