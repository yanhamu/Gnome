using Gnome.Core.Model;
using Gnome.Core.Model.Database;
using System;

namespace Gnome.Api.IntegrationTests.Fixtures
{
    public static class AccountFixtures
    {
        private static Account fio;

        public static Account Fio
        {
            get
            {
                if (fio == null)
                {
                    fio = new Account(new Guid("6ed46731-9265-49f8-9fa5-f9c7a92dbde2"), UserFixture.User.Id, "fio", "token");
                }
                return fio;
            }
        }

        private static Account csob;

        public static Account Csob
        {
            get
            {
                if (csob == null)
                {
                    csob = new Account(new Guid("2362b9c6-e334-4f5f-86dd-c2ad6659ae4c"), UserFixture.User.Id, "csob", null);
                }
                return csob;
            }
        }
    }
}
