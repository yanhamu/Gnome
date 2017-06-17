using Dapper;
using Gnome.Core.Model;
using System.Data.SqlClient;

namespace Gnome.Core.DataAccess
{
    public class UserRepository
    {
        private readonly SqlConnection connection;

        public UserRepository(SqlConnection connection)
        {
            this.connection = connection;
        }

        public bool CheckEmailAvailability(string email)
        {
            var sql = "select 1 from [user] where email = @email";
            var result = connection.ExecuteScalar<int?>(sql, new { email = email });
            return result == null;
        }

        public User GetUser(string email)
        {
            var sql = "select id, email from [user] where email = @email";
            return connection.QueryFirst<User>(sql, new { email = email });
        }
    }
}
