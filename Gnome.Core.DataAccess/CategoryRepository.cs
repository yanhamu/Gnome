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

        public void Save()
        {
            this.context.SaveChanges();
        }

        public Category Create(Category category)
        {
            var result = this.context.Categories.Add(category);
            this.context.SaveChanges();
            return result.Entity;
        }

        public void Remove(List<int> toDelete)
        {
            var categories = context.Categories.Where(c => toDelete.Contains(c.Id)).ToList();
            categories.ForEach(c => context.Categories.Remove(c));
        }
    }
}