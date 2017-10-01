using Gnome.Core.Model.Database;

namespace Gnome.Core.DataAccess
{
    public interface IQueryRepository : IGenericRepository<Query> { }

    public class QueryRepository : GenericRepository<Query>, IQueryRepository
    {
        public QueryRepository(GnomeDb context) : base(context) { }
    }
}