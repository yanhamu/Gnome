using System.Linq;

namespace Gnome.Core.DataAccess
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> Query { get; }
        T Create(T entity);
        T Find(params object[] ids);
        T Remove(params object[] ids);
        int Save(); //TODO reevaluate
    }
}