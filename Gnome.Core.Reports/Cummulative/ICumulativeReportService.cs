using System;
using System.Collections.Generic;
using Gnome.Core.Service.Search.Filters;

namespace Gnome.Core.Reports.Cummulative
{
    public interface ICumulativeReportService
    {
        List<Aggregate> Report(TransactionSearchFilter filter, Guid userId);
    }
}