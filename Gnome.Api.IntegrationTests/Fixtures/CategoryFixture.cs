using Gnome.Core.Model.Database;
using System;

namespace Gnome.Api.IntegrationTests.Fixtures
{
    public static class CategoryFixture
    {
        private static Category root;
        public static Category Root
        {
            get
            {
                if (root == null)
                    root = new Category()
                    {
                        Id = new Guid("e07ed20d-ffdc-49a9-999a-5dd3f50b767a"),
                        Color = "FF0000",
                        IsSystem = true,
                        Name = "root",
                        UserId = UserFixture.User.Id
                    };
                return root;
            }
        }

        private static Category unassigned;

        public static Category UnAssigned
        {
            get
            {
                if (unassigned == null)
                    unassigned = new Category()
                    {
                        Id = new Guid("11fbedc5-44f1-4b02-9cf2-3e11d8489b5b"),
                        Color = "00FF00",
                        IsSystem = true,
                        Name = "unassigned",
                        ParentId = CategoryFixture.Root.Id,
                        UserId = UserFixture.User.Id
                    };
                return unassigned;
            }
        }

        private static Category userCategory;

        public static Category UserCategory
        {
            get
            {
                if (userCategory == null)
                    userCategory = new Category()
                    {
                        Id = new Guid("cebc753f-b2c7-4675-a86d-fdfaf6a07d1d"),
                        Color = "00FFDD",
                        IsSystem = false,
                        Name = "user category",
                        ParentId = CategoryFixture.Root.Id,
                        UserId = UserFixture.User.Id
                    };
                return userCategory;
            }
        }

    }
}
