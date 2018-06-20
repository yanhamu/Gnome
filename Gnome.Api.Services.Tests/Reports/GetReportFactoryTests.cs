using Gnome.Api.Services.Reports;
using Gnome.Api.Services.Reports.Requests;
using Gnome.Core.DataAccess;
using Gnome.Core.Service.Search.Filters;
using NSubstitute;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Gnome.Api.Services.Tests.Reports
{
    public class GetReportFactoryTests
    {
        [Fact]
        public async Task Should_Return_Request()
        {
            var repository = Substitute.For<IReportRepository>();
            var factory = new GetReportRequestFactory(repository);

            SetReportReturnType(repository, "aggregate");
            var aggregateRequest = await factory.Create(default(Guid), default(ClosedInterval), default(Guid));
            Assert.IsType<GetAggregateReport>(aggregateRequest);

            SetReportReturnType(repository, "cumulative");
            var cumulativeRequest = await factory.Create(default(Guid), default(ClosedInterval), default(Guid));
            Assert.IsType<GetCumulativeReport>(cumulativeRequest);

            SetReportReturnType(repository, "total-monthly");
            var totalMonthlyRequest = await factory.Create(default(Guid), default(ClosedInterval), default(Guid));
            Assert.IsType<GetTotalMonthlyReport>(totalMonthlyRequest);
        }

        private static void SetReportReturnType(IReportRepository repository, string reportReturnType)
        {
            repository.Find(Arg.Any<object[]>()).Returns(new Core.Model.Database.Report() { Type = reportReturnType });
        }
    }
}