using Gnome.Core.Model;
using System.Linq;

namespace Gnome.Core.Service.Search.QueryBuilders
{
    public interface IQueryBuilder<T>
    {
        IQueryable<Transaction> Build(IQueryable<Transaction> query, T filterDefinition);
    }
}