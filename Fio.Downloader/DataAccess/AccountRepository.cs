using Fio.Downloader.Model;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;

namespace Fio.Downloader.DataAccess
{
    public class AccountRepository
    {
        private readonly SqliteConnection connection;

        public AccountRepository(SqliteConnection connection)
        {
            this.connection = connection;
        }

        public IEnumerable<Account> GetAccountsToSync()
        {
            var sql = "select id, token from fio_account where token is not null";

            var accounts = new List<Account>();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = sql;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var account = new Account()
                        {
                            Id = reader.GetGuid(0),
                            Token = reader.GetString(1)
                        };
                        accounts.Add(account);
                    }
                }
            }
            return accounts;
        }
    }
}
