namespace Gnome.Core.DataAccess
{
    public class CategoryTransactionRepository
    {
        private readonly GnomeDb context;

        public CategoryTransactionRepository(GnomeDb context)
        {
            this.context = context;
        }
    }
}
