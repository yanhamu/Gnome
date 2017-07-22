using Gnome.Core.DataAccess;
using Gnome.Core.Model;

namespace Gnome.Core.Service.Categories
{
    public interface ICategoryInitializeService
    {
        void Initialize(int userId);
    }

    public class CategoryInitializeService: ICategoryInitializeService
    {
        private readonly ICategoryRepository repository;

        public CategoryInitializeService(ICategoryRepository repository)
        {
            this.repository = repository;
        }

        public void Initialize(int userId)
        {
            var root = repository.Create(new Category()
            {
                IsSystem = true,
                Name = "root",
                Type = Category.TypeEnumeration.Envelope,
                UserId = userId
            });
            repository.Save();

            var system = repository.Create(new Category()
            {
                IsSystem = true,
                Name = "system",
                ParentId = root.Id,
                UserId = userId,
                Type = Category.TypeEnumeration.Envelope
            });
            repository.Save();

            var unread = repository.Create(new Category()
            {
                IsSystem = true,
                Name = "unread",
                ParentId = system.Id,
                UserId = userId,
                Type = Category.TypeEnumeration.Envelope
            });
            repository.Save();

            var user = repository.Create(new Category()
            {
                IsSystem = false,
                Name = "User Category",
                ParentId = root.Id,
                UserId = userId,
                Type = Category.TypeEnumeration.Envelope
            });
            repository.Save();

            var other = repository.Create(new Category()
            {
                IsSystem = false,
                Name = "Other",
                ParentId = user.Id,
                UserId = userId,
                Type = Category.TypeEnumeration.Fallback
            });
            repository.Save();
        }
    }
}
