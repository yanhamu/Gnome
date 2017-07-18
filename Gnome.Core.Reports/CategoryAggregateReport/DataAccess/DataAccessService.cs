using Gnome.Core.DataAccess;

namespace Gnome.Core.Reports.CategoryAggregateReport.DataAccess
{
    public class DataAccessService
    {
        private readonly GnomeDb context;

        public DataAccessService(GnomeDb context)
        {
            this.context = context;
        }


    }
}
