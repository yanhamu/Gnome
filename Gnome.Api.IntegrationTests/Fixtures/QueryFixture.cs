using Gnome.Core.Model.Database;
using System;

namespace Gnome.Api.IntegrationTests.Fixtures
{
    public static class QueryFixture
    {
        private static Query queryAll;

        public static Query QueryAll
        {
            get
            {
                if (queryAll == null)
                    queryAll = new Query()
                    {
                        Id = new Guid("33d7ec3a-b3ad-4ebb-b3ff-b792abe0d410"),
                        Data = "1 = 1",
                        Name = "All",
                        UserId = UserFixture.User.Id
                    };
                return queryAll;
            }
        }

    }
}
