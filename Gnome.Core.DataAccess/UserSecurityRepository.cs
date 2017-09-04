using Gnome.Core.Model;
using Microsoft.Data.Sqlite;
using System;

namespace Gnome.Core.DataAccess
{
    public interface IUserSecurityRepository
    {
        UserSecurity CreateNew(string email, byte[] pwd, byte[] salt, Guid userId);
        UserSecurity GetBy(string email);
    }

    public class UserSecurityRepository : IUserSecurityRepository
    {
        private readonly SqliteConnection connection;

        public UserSecurityRepository(SqliteConnection connection)
        {
            this.connection = connection;
        }

        public UserSecurity CreateNew(string email, byte[] pwd, byte[] salt, Guid userId)
        {
            var sql = "insert into [user] values(@userId, @email, @pwd, @salt)";
            using (var command = connection.CreateCommand())
            {
                command.CommandText = sql;
                command.Parameters.Add(CreateParameter("@userId", userId));
                command.Parameters.Add(CreateParameter("@email", email));
                command.Parameters.Add(CreateParameter("@pwd", pwd));
                command.Parameters.Add(CreateParameter("@salt", salt));

                if (command.ExecuteNonQuery() != 1)
                    throw new InvalidOperationException("User was not created!");
            }

            return GetBy(email);
        }

        public UserSecurity GetBy(string email)
        {
            var sql = "select id, email, pwd as 'password', salt from [user] where email = @email";
            using (var command = connection.CreateCommand())
            {
                command.CommandText = sql;
                command.Parameters.Add(CreateParameter("email", email));
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return new UserSecurity()
                        {
                            Id = reader.GetGuid(0),
                            Email = reader.GetString(1),
                            Password = (byte[])reader[2],
                            Salt = (byte[])reader[3]
                        };
                    }
                }
            }

            return null;
        }

        private SqliteParameter CreateParameter<T>(string name, T value)
        {
            return new SqliteParameter(name, value);
        }
    }
}