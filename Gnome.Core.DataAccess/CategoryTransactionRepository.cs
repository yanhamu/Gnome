using Gnome.Core.Model;

namespace Gnome.Core.DataAccess
{
    public class CategoryTransactionRepository : GenericRepository<CategoryTransaction>
    {
        public CategoryTransactionRepository(GnomeDb context) : base(context) { }
    }
}
