namespace Gnome.Core.DataAccess
{
    public class CategoryRepository
    {
        private readonly GnomeDb context;

        public CategoryRepository(GnomeDb context)
        {
            this.context = context;
        }


    }
}
