using System.Linq;

namespace Gnome.Core.Service.Search.QueryBuilders
{
    public interface IQueryBuilderService<TEntity, TFilter>
    {
        IQueryable<TEntity> Filter(IQueryable<TEntity> query, TFilter filter);
    }
}
