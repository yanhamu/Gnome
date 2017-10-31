using Gnome.Api.IntegrationTests.Extensions;
using Gnome.Api.IntegrationTests.Fixtures;
using Gnome.Api.Services.Reports;
using Gnome.Api.Services.Reports.Requests;
using System;
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

        [Fact]
        public async void Should_List_Reports()
        {
            server.PrepareUser(UserFixture.User);
            server.PrepareAccount(AccountFixtures.Fio);
            server.PrepareQuery(QueryFixture.QueryAll);
            server.PrepareReport(ReportFixture.BasicAggregate);

            var response = await client.List();
            response.HasStatusCode(HttpStatusCode.OK);
        }

        [Fact]
        public async void Should_Get_Report()
        {
            server.PrepareUser(UserFixture.User);
            server.PrepareCategory(CategoryFixture.Root);
            server.PrepareAccount(AccountFixtures.Fio);
            server.PrepareQuery(QueryFixture.QueryAll);
            server.PrepareReport(ReportFixture.BasicAggregate);
            server.PrepareReport(ReportFixture.CumulativeReport);
            server.PrepareReport(ReportFixture.TotalMonthly);

            client.SetBaseUrl(GetReportUrl(ReportFixture.BasicAggregate.Id));
            (await client.Get(ReportFixture.BasicAggregate.Id)).HasStatusCode(HttpStatusCode.OK);

            client.SetBaseUrl(GetReportUrl(ReportFixture.CumulativeReport.Id));
            (await client.Get(ReportFixture.CumulativeReport.Id)).HasStatusCode(HttpStatusCode.OK);

            client.SetBaseUrl(GetReportUrl(ReportFixture.TotalMonthly.Id));
            (await client.Get(ReportFixture.TotalMonthly.Id)).HasStatusCode(HttpStatusCode.OK);
        }

        [Fact]
        public async void Should_Remove_Report()
        {
            server.PrepareUser(UserFixture.User);
            server.PrepareAccount(AccountFixtures.Fio);
            server.PrepareQuery(QueryFixture.QueryAll);
            server.PrepareReport(ReportFixture.BasicAggregate);

            var response = await client.Remove(ReportFixture.BasicAggregate.Id);

            response.HasStatusCode(HttpStatusCode.NoContent);
        }

        [Fact]
        public async void Should_Update_Report()
        {
            server.PrepareUser(UserFixture.User);
            server.PrepareAccount(AccountFixtures.Fio);
            server.PrepareQuery(QueryFixture.QueryAll);
            server.PrepareReport(ReportFixture.BasicAggregate);

            var updateReport = new UpdateReport()
            {
                Id = ReportFixture.BasicAggregate.Id,
                Name = "Updated name",
                QueryId = ReportFixture.BasicAggregate.QueryId,
                Type = ReportFixture.BasicAggregate.Type
            };

            var response = await client.Update(ReportFixture.BasicAggregate.Id, updateReport);
            response.HasStatusCode(HttpStatusCode.OK);
        }

        private string GetReportUrl(Guid id)
        {
            return $"api/reports/{id.ToString()}?from=2017-01-01&to=2017-02-01";
        }
    }
}