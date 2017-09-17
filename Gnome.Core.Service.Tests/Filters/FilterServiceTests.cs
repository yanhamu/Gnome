using Gnome.Core.Service.Filters;
using System;
using Xunit;

namespace Gnome.Core.Service.Tests.Filters
{
    public class FilterServiceTests
    {
        [Fact]
        public void Should_Return_Filter()
        {
            var id = Guid.NewGuid();
            var service = new FilterService(null);
            var filter = service.Get(id);
        }
    }
}
