using System;
using System.Threading.Tasks;

namespace Gnome.Core.Service.Categories
{
    public interface ICategoryTreeFactory
    {
        Task<CategoryTree> Create(Guid userId);
    }
}