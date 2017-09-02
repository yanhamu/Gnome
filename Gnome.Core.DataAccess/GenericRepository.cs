using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace Gnome.Core.DataAccess
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly GnomeDb context;
        protected readonly DbSet<T> set;

        public GenericRepository(GnomeDb context)
        {
            this.context = context;
            this.set = context.Set<T>();
        }

        public virtual T Find(params object[] ids)
        {
            return set.Find(ids);
        }

        public virtual T Remove(params object[] ids)
        {
            var toRemove = set.Find(ids);
            var removed = set.Remove(toRemove);
            return removed.Entity;
        }
        public virtual T Create(T entity)
        {
            return this.set.Add(entity).Entity;
        }

        public virtual int Save()
        {
            return this.context.SaveChanges();
        }

        public IQueryable<T> Query { get { return set; } }
    }
}