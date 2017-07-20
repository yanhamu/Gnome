using Gnome.Core.Model;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Core.DataAccess
{
    public interface ICategoryRepository
    {
        List<Category> GetAll(int userId);
    }

    public class CategoryRepository : ICategoryRepository
    {
        private readonly GnomeDb context;

        public CategoryRepository(GnomeDb context)
        {
            this.context = context;
        }

        public List<Category> GetAll(int userId)
        {
            return context.Categories.Where(c => c.UserId == userId).ToList();
        }

        public Category GetById(int id)
        {
            return context.Categories.Find(id);
        }
    }
}