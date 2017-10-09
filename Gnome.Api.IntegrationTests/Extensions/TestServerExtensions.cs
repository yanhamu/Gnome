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

        public static void PrepareTransaction(this TestServer server, Transaction transaction)
        {
            var connection = GetConnection(server);
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "insert into [transaction] values(@id, @account_id, @date, @amount, @type, @data)";
                command.Parameters.Add(new SqliteParameter("id", transaction.Id));
                command.Parameters.Add(new SqliteParameter("account_id", transaction.AccountId));
                command.Parameters.Add(new SqliteParameter("date", transaction.Date));
                command.Parameters.Add(new SqliteParameter("amount", transaction.Amount));
                command.Parameters.Add(new SqliteParameter("type", transaction.Type));
                command.Parameters.Add(new SqliteParameter("data", (object)transaction.Data ?? DBNull.Value));
                command.ExecuteNonQuery();
            }
        }

        public static void PrepareCategory(this TestServer server, Category category)
        {
            var connection = GetConnection(server);
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "insert into [category] values(@id, @user_id, @parent_id, @name, @is_system, @color)";
                command.Parameters.Add(new SqliteParameter("id", category.Id));
                command.Parameters.Add(new SqliteParameter("user_id", category.UserId));
                command.Parameters.Add(new SqliteParameter("parent_id", (object)category.ParentId ?? DBNull.Value));
                command.Parameters.Add(new SqliteParameter("name", category.Name));
                command.Parameters.Add(new SqliteParameter("is_system", category.IsSystem));
                command.Parameters.Add(new SqliteParameter("color", (object)category.Color ?? DBNull.Value));
                command.ExecuteNonQuery();
            }
        }

        public static void PrepareExpression(this TestServer server, Expression expression)
        {
            var connection = GetConnection(server);
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "insert into [expression] values(@id, @user_id, @name, @expressionString)";
                command.Parameters.Add(new SqliteParameter("id", expression.Id));
                command.Parameters.Add(new SqliteParameter("user_id", expression.UserId));
                command.Parameters.Add(new SqliteParameter("name", expression.Name));
                command.Parameters.Add(new SqliteParameter("expressionString", expression.ExpressionString));
                command.ExecuteNonQuery();
            }
        }

        public static void PrepareQuery(this TestServer server, Query query)
        {
            var connection = GetConnection(server);
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "insert into [query] values(@id, @userid, @name, @data)";
                command.Parameters.Add(new SqliteParameter("id", query.Id));
                command.Parameters.Add(new SqliteParameter("userid", query.UserId));
                command.Parameters.Add(new SqliteParameter("name", query.Name));
                command.Parameters.Add(new SqliteParameter("data", query.Data));
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
