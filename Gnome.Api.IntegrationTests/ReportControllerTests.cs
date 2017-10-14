using Gnome.Api.IntegrationTests.Extensions;
using Gnome.Api.IntegrationTests.Fixtures;
using Gnome.Api.Services.Reports;
using Gnome.Api.Services.Reports.Requests;
using System.Net;
using Xunit;

namespace Gnome.Api.IntegrationTests
{
    public class ReportControllerTests : BaseControllerTests
    {
        public ReportControllerTests() : base("api/reports") { }

        [Fact]
        public async void Should_Create_Report()
        {
            server.PrepareUser(UserFixture.User);
            server.PrepareAccount(AccountFixtures.Fio);
            server.PrepareQuery(QueryFixture.QueryAll);

            var response = await client.Create(new CreateReport()
            {
                QueryId = ReportFixture.BasicAggregate.QueryId,
                UserId = ReportFixture.BasicAggregate.UserId,
                Type = ReportFixture.BasicAggregate.Type,
                Name = ReportFixture.BasicAggregate.Name
            });

            response.HasStatusCode(HttpStatusCode.OK);
            var report = await response.Deserialize<Report>();

            Assert.Equal(ReportFixture.BasicAggregate.QueryId, report.QueryId);
            Assert.Equal(ReportFixture.BasicAggregate.Name, report.Name);
            Assert.Equal(ReportFixture.BasicAggregate.Type, report.Type);
        }
    }
}