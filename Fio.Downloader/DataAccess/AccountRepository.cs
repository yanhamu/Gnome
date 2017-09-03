using Dapper;
using Fio.Downloader.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Fio.Downloader.DataAccess
{
    public class AccountRepository
    {
        private readonly SqlConnection connection;

        public AccountRepository(SqlConnection connection)
        {
            this.connection = connection;
        }

        public IEnumerable<Account> GetAccountsToSync()
        {
            var sql = "select id, token, last_sync as 'LastSync' from fio_account where token is not null";
            return connection.Query<Account>(sql);
        }
    }
}
