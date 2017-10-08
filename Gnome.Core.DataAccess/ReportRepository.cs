using Gnome.Core.Model.Database;

namespace Gnome.Core.DataAccess
{
    public interface IReportRepository : IGenericRepository<Report> { }

    public class ReportRepository : GenericRepository<Report>, IReportRepository
    {
        public ReportRepository(GnomeDb context) : base(context) { }
    }
}
