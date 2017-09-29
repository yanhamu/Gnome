using StructureMap;

namespace Gnome.Infrastructure
{
    public class ReportingRegistry : Registry
    {
        public ReportingRegistry()
        {
            Scan(_ =>
            {
                _.AssemblyContainingType<Gnome.Core.Reports.AggregateReport.IAggregateReportService>();
                _.Include(t => t.Name.EndsWith("Service"));
                _.WithDefaultConventions();
            });
        }
    }
}
