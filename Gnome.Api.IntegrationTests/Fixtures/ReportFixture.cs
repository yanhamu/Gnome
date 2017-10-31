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

        private static Report cumulativeReport;

        public static Report CumulativeReport
        {
            get
            {
                if (cumulativeReport == null)
                    cumulativeReport = new Report()
                    {
                        Id = new Guid("0a3178fd-a7ec-45d4-aeaa-c4c6820c4397"),
                        Name = "Cumulative Report",
                        QueryId = QueryFixture.QueryAll.Id,
                        UserId = UserFixture.User.Id,
                        Type = "cumulative"
                    };
                return cumulativeReport;
            }
        }

        private static Report totalMonthly;

        public static Report TotalMonthly
        {
            get
            {
                if (totalMonthly == null)
                {
                    totalMonthly = new Report()
                    {
                        Id = new Guid("9056ab96-89f9-4bab-9203-d7f1ed62c0a3"),
                        Name = "Total monthly",
                        QueryId = QueryFixture.QueryAll.Id,
                        UserId = UserFixture.User.Id,
                        Type = "total-monthly"
                    };
                }
                return totalMonthly;
            }
        }

    }
}
