using Gnome.Core.Model;
using Gnome.Core.Service.Query;
using System;
using System.Collections.Generic;
using Xunit;

namespace Gnome.Core.Service.Tests.Query
{
    public class QueryDataServiceTests
    {
        [Fact]
        public void Should_Serialize_QueryData()
        {
            var service = new QueryDataService();
            var model = new QueryData(new List<Guid>(), new List<Guid>(), new List<Guid>());
            var serialized = service.Serialize(model);

            Assert.Equal("{\"Accounts\":[],\"IncludeExpressions\":[],\"ExcludeExpressions\":[]}", serialized);
        }

        [Fact]
        public void Should_Deserialize_QueryData()
        {
            var service = new QueryDataService();
            var model = service.Deserialize("{\"Accounts\":[\"6ed46731-9265-49f8-9fa5-f9c7a92dbde2\"],\"IncludeExpressions\":[],\"ExcludeExpressions\":[]}");

            Assert.Contains(model.Accounts, a => a == new Guid("6ed46731-9265-49f8-9fa5-f9c7a92dbde2"));
            Assert.Empty(model.IncludeExpressions);
            Assert.Empty(model.ExcludeExpressions);
        }
    }
}
