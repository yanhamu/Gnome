using Dapper;
using Gnome.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Gnome.Core.DataAccess
{
    public class FioAccountRepository
    {
        private readonly SqlConnection connection;

        public FioAccountRepository(SqlConnection connection)
        {
            this.connection = connection;
        }

        public int Create(FioAccount account)
        {
            var sql = @"
insert into fio_account values(@userId, @name, @token);
select cast(SCOPE_IDENTITY() as int)";
            var id = connection
                .Query<int>(sql, new { userId = account.UserId, name = account.Name, token = account.Token })
                .Single();

            return id;
        }

        public FioAccount Get(int accountId)
        {
            var sql = "select * from fio_account where id = @id";
            return connection.Query<FioAccount>(sql, new { id = accountId }).SingleOrDefault();
        }

        public IEnumerable<FioAccount> GetAccounts(int userId)
        {
            var sql = "select * from fio_account where userid = @userId";
            return connection.Query<FioAccount>(sql, new { userId = userId });
        }

        public void Remove(int accountId)
        {
            var sql = "delete from fio_account where id = @id";
            connection.Execute(sql, new { id = accountId });
        }

        public void Update(int accountId, FioAccount account)
        {
            var sql = "update fio_account set name = @name, token = @token where id = @id";
            var affectedRows = connection.Execute(sql, new { name = account.Name, token = account.Token, id = accountId });
            if (affectedRows != 1)
                throw new InvalidOperationException();
        }
    }
}
