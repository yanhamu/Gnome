using System.Linq;
using System.Threading.Tasks;

namespace Gnome.Core.DataAccess
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> Query { get; }
        T Create(T entity);
        Task<T> Find(params object[] ids);
        T Remove(params object[] ids);
        Task<int> Save();
    }
}