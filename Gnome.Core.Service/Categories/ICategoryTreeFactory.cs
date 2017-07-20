namespace Gnome.Core.Service.Categories
{
    public interface ICategoryTreeFactory
    {
        CategoryTree Create(int userId);
    }
}