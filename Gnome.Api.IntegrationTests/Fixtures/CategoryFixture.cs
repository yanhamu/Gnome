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
                        Type = Category.TypeEnumeration.Envelope,
                        UserId = UserFixture.User.Id
                    };
                return root;
            }
        }
    }
}
