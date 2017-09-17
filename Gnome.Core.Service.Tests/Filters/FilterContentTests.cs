using Gnome.Core.Service.Filters;
using System;
using System.Collections.Generic;
using Xunit;

namespace Gnome.Core.Service.Tests.Filters
{
    public class FilterContentTests
    {
        [Fact]
        public void Should_Create_FilterContent()
        {
            var g1 = new Guid("f4933933-e3a7-4db8-b918-dd9060e0dff7");
            var g2 = new Guid("3c573ede-5d54-4fe8-834d-48e0afe14785");
            var g3 = new Guid("00620ab6-28ac-4356-8322-4ac2acc29133");

            var included = new List<Guid>() { g1, g2 };
            var excluded = new List<Guid>();
            var accounts = new List<Guid>() { g3 };

            var f = new FilterContent(included, excluded, accounts);

            var serialized = FilterContent.Create(f);
            var filterContent = FilterContent.Create(serialized);

            Assert.Equal(f.Accounts[0], filterContent.Accounts[0]);
            Assert.Equal(f.Included[0], filterContent.Included[0]);
            Assert.Equal(f.Included[1], filterContent.Included[1]);

            Assert.Empty(f.Excluded);

            Assert.Equal(f.Accounts[0], filterContent.Accounts[0]);
        }
    }
}
