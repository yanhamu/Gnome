using Gnome.Core.Model;
using Gnome.Core.Service.Search.Filters;
using System.Linq;

namespace Gnome.Core.Service.Search.QueryBuilders
{
    public interface IQueryBuilder
    {
        IQueryable<Transaction> Build(IQueryable<Transaction> query, SearchFilter filter);
    }
}
