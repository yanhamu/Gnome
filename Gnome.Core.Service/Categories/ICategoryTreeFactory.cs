using System;

namespace Gnome.Core.Service.Categories
{
    public interface ICategoryTreeFactory
    {
        CategoryTree Create(Guid userId);
    }
}