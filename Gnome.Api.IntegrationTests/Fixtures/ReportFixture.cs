using Gnome.Core.Model.Database;
using System;

namespace Gnome.Api.IntegrationTests.Fixtures
{
    public static class ReportFixture
    {
        private static Report basicAggregate;
        public static Report BasicAggregate
        {
            get
            {
                if (basicAggregate == null)
                    basicAggregate = new Report()
                    {
                        Id = new Guid("805811ca-53f3-40b6-ad1a-80b69d9716de"),
                        Name = "Basic Aggregate",
                        QueryId = QueryFixture.QueryAll.Id,
                        UserId = UserFixture.User.Id,
                        Type = "aggregate"
                    };
                return basicAggregate;
            }
        }
    }
}
