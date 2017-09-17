using Gnome.Core.Model.Database;

namespace Gnome.Api.IntegrationTests.Fixtures
{
    public static class UserFixture
    {
        private static User user;

        public static User User
        {
            get
            {
                if (user == null)
                {
                    user = new User()
                    {
                        Id = new System.Guid("8d973175-8a72-40a6-9a54-c251a632e8da"),
                        Email = "email@email.com"
                    };
                }

                return user;
            }
        }

    }
}
