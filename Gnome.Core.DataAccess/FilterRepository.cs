using Gnome.Core.Model;

namespace Gnome.Core.DataAccess
{
    public interface IFilterRepository : IGenericRepository<Filter> { }

    public class FilterRepository : GenericRepository<Filter>, IFilterRepository
    {
        public FilterRepository(GnomeDb context) : base(context) { }
    }
}