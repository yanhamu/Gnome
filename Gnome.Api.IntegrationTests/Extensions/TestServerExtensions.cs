using Gnome.Core.Model.Database;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Data.Sqlite;
using System;

namespace Gnome.Api.IntegrationTests.Extensions
{
    public static class TestServerExtensions
    {
        public static void PrepareUser(this TestServer server, User user)
        {
            var connection = GetConnection(server);

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "insert into user values(@id, @email, @pwd, @salt)";
                command.Parameters.Add(new SqliteParameter("id", user.Id));
                command.Parameters.Add(new SqliteParameter("email", user.Email));
                command.Parameters.Add(new SqliteParameter("pwd", new byte[] { 0 }));
                command.Parameters.Add(new SqliteParameter("salt", new byte[] { 0 }));
                command.ExecuteNonQuery();
            }
        }

        public static void PrepareAccount(this TestServer server, Account account)
        {
            var connection = GetConnection(server);
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "insert into account values(@id, @userid, @name, @token)";
                command.Parameters.Add(new SqliteParameter("id", account.Id));
                command.Parameters.Add(new SqliteParameter("userid", account.UserId));
                command.Parameters.Add(new SqliteParameter("name", account.Name));
                command.Parameters.Add(new SqliteParameter("token", (object)account.Token ?? DBNull.Value));
                command.ExecuteNonQuery();
            }
        }

        public static HttpClientWrapper CreateClientWrapper(this TestServer server)
        {
            return new HttpClientWrapper(server.CreateClient());
        }

        private static SqliteConnection GetConnection(TestServer server)
        {
            return (SqliteConnection)server.Host.Services.GetService(typeof(SqliteConnection));
        }
    }
}
