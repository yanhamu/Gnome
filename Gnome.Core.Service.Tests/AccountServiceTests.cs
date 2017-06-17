using Dapper;
using Gnome.Core.Service.Interfaces;
using Gnome.Tests.Common;
using System;
using System.Data.SqlClient;
using Xunit;

namespace Gnome.Core.Service.Tests
{
    public class AccountServiceTests : IDisposable
    {
        [Fact]
        public void Should_Create_New_Account_Tests()
        {
        }

        public void Dispose()
        {
            using (var connection = new SqlConnection(Database.ConnectionString))
            {
                connection.Execute(Database.Clear_All);
            }
        }

        private IAccountService GetService(SqlConnection connection)
        {
            throw new NotImplementedException();
        }
    }
}
