using Gnome.Core.Model.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gnome.Core.DataAccess
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<List<Category>> GetAll(Guid userId);
    }

    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(GnomeDb context) : base(context) { }

        public Task<List<Category>> GetAll(Guid userId)
        {
            return context.Categories.Where(c => c.UserId == userId).ToListAsync();
        }

        public void Remove(List<Guid> toDelete)
        {
            var categories = context.Categories.Where(c => toDelete.Contains(c.Id)).ToList();
            categories.ForEach(c => context.Categories.Remove(c));
        }
    }
}