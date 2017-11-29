using Gnome.Core.DataAccess;
using Gnome.Core.Model.Database;
using System;

namespace Gnome.Core.Service.Initialization
{
    public class CategoryInitializeService : IInitializationService
    {
        private readonly ICategoryRepository repository;

        public int Order => 10;

        public CategoryInitializeService(ICategoryRepository repository)
        {
            this.repository = repository;
        }

        public void Initialize(Guid userId)
        {
            var root = repository.Create(new Category()
            {
                Id = Guid.NewGuid(),
                IsSystem = true,
                Name = Constants.Categories.Root,
                UserId = userId,
                Color = "#333333"
            });
            repository.Save();

            var system = repository.Create(new Category()
            {
                Id = Guid.NewGuid(),
                IsSystem = true,
                Name = Constants.Categories.System,
                ParentId = root.Id,
                UserId = userId,
                Color = "#333333"
            });
            repository.Save();

            var unread = repository.Create(new Category()
            {
                Id = Guid.NewGuid(),
                IsSystem = true,
                Name = Constants.Categories.New,
                ParentId = system.Id,
                UserId = userId,
                Color = "#333333"
            });
            repository.Save();
        }
    }
}
