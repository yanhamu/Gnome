using Gnome.Core.Model.Database;

namespace Gnome.Core.DataAccess
{
    public interface IFilterRepository : IGenericRepository<Filter>
    {

    }

    public class FilterRepository : GenericRepository<Filter>
    {
        public FilterRepository(GnomeDb context) : base(context) { }
    }
}
