using Gnome.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Core.DataAccess
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        List<Category> GetAll(Guid userId);
    }

    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(GnomeDb context) : base(context) { }

        public List<Category> GetAll(Guid userId)
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