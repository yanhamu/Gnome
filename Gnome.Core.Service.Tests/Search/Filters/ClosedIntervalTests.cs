using Gnome.Core.Service.Search.Filters;
using System;
using Xunit;

namespace Gnome.Core.Service.Tests.Search.Filters
{
    public class ClosedIntervalTests
    {
        [Fact]
        public void Should_Be_Equal()
        {
            var a = new ClosedInterval(new DateTime(2017, 1, 2), new DateTime(2017, 1, 3));
            var b = new ClosedInterval(new DateTime(2017, 1, 2), new DateTime(2017, 1, 3));

            Assert.Equal(a, b);
            Assert.True(a == b);
        }

        [Fact]
        public void Should_Be_NotEqual()
        {
            Assert.NotEqual(
                new ClosedInterval(new DateTime(2017, 1, 2), new DateTime(2017, 1, 3)),
                new ClosedInterval(new DateTime(2017, 1, 1), new DateTime(2017, 1, 3)));

            Assert.NotEqual(
                new ClosedInterval(new DateTime(2017, 1, 2), new DateTime(2017, 1, 3)),
                new ClosedInterval(new DateTime(2017, 1, 2), new DateTime(2017, 1, 4)));

            Assert.NotEqual(
                new ClosedInterval(new DateTime(2017, 1, 2), new DateTime(2017, 1, 3)),
                new ClosedInterval(new DateTime(2017, 1, 1), new DateTime(2017, 1, 4)));

            Assert.True(new ClosedInterval(new DateTime(2017, 1, 1), new DateTime(2017, 1, 4)) != new ClosedInterval(new DateTime(2017, 1, 2), new DateTime(2017, 1, 3)));

            Assert.False(new ClosedInterval(new DateTime(2017, 1, 2), new DateTime(2017, 1, 3)).Equals(new Object()));
        }
    }
}
