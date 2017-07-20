using Gnome.Core.Model;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Core.DataAccess
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        List<Category> GetAll(int userId);
    }

    public class CategoryRepository : GenericRepository<Category>
    {
        public CategoryRepository(GnomeDb context) : base(context) { }

        public List<Category> GetAll(int userId)
        {
            return context.Categories.Where(c => c.UserId == userId).ToList();
        }

        public void Remove(List<int> toDelete)
        {
            var categories = context.Categories.Where(c => toDelete.Contains(c.Id)).ToList();
            categories.ForEach(c => context.Categories.Remove(c));
        }
    }
}