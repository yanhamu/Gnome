using Gnome.Core.Model;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Core.DataAccess
{
    public class CategoryRepository
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
    }
}