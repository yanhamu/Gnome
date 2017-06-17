using Dapper;
using Gnome.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Gnome.Core.DataAccess
{
    public class AccountRepository
    {
        private readonly SqlConnection connection;

        public AccountRepository(SqlConnection connection)
        {
            this.connection = connection;
        }

        public int Create(Account account)
        {
            var sql = @"
insert into account values(@userId, @name, @token);
select cast(SCOPE_IDENTITY() as int)";
            var id = connection
                .Query<int>(sql, new { userId = account.UserId, name = account.Name, token = account.Token })
                .Single();

            return id;
        }

        public Account Get(int accountId)
        {
            var sql = "select * from account where id = @id";
            return connection.QueryFirst<Account>(sql, new { id = accountId });
        }

        public IEnumerable<Account> GetAccounts(int userId)
        {
            var sql = "select * from account where userid = @userId";
            return connection.Query<Account>(sql, new { userId = userId });
        }

        public Account Remove(int accountId)
        {
            throw new NotImplementedException();
        }

        public Account Update(int accountId, Account account)
        {
            throw new NotImplementedException();
        }
    }
}
