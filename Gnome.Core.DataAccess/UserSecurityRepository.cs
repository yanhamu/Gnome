using Dapper;
using Gnome.Core.Model;
using System.Data.SqlClient;

namespace Gnome.Core.DataAccess
{
    public interface IUserSecurityRepository
    {
        UserSecurity CreateNew(string email, byte[] pwd, byte[] salt);
        UserSecurity GetBy(string email);
    }

    public class UserSecurityRepository : IUserSecurityRepository
    {
        private readonly SqlConnection connection;

        public UserSecurityRepository(SqlConnection connection)
        {
            this.connection = connection;
        }
        public UserSecurity CreateNew(string email, byte[] pwd, byte[] salt)
        {
            var sql = "insert into [user] values(@email, @pwd, @salt)";
            var result = connection.Execute(sql, new { email = email, pwd = pwd, salt = salt });
            return GetBy(email);
        }

        public UserSecurity GetBy(string email)
        {
            var sql = "select id, email, pwd as 'password', salt from [user] where email = @email";
            var result = connection.QueryFirstOrDefault<UserSecurity>(sql, new { email = email });
            return result;
        }
    }
}