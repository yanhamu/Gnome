using Gnome.Core.Model;

namespace Gnome.Core.DataAccess
{
    public interface ICategoryTransactionRepository : IGenericRepository<CategoryTransaction> { }

    public class CategoryTransactionRepository : GenericRepository<CategoryTransaction>, ICategoryTransactionRepository
    {
        public CategoryTransactionRepository(GnomeDb context) : base(context) { }
    }
}
