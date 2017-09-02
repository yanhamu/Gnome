using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Gnome.Database
{
    public class Initializer
    {
        private readonly SqliteConnection sqlConnection;
        private readonly string sqlFilePath;
        private List<string> createTableFiles { get; }

        public Initializer(SqliteConnection sqlConnection, string sqlFilePath)
        {
            this.sqlConnection = sqlConnection;
            this.sqlFilePath = sqlFilePath;
            this.createTableFiles = new List<string>() {
                "user",
                "fio_account",
                "category",
                "transaction",
                "category_transaction"
            };
        }

        public void Initialize(bool dropIfExists)
        {
            if (dropIfExists)
            {
                createTableFiles
                    .AsEnumerable()
                    .Reverse()
                    .Where(f => ExistTable(f))
                    .ToList()
                    .ForEach(f => DropTable(f));
            }

            createTableFiles
                .ForEach(f => CreateTable(f));
        }

        private void DropTable(string tableName)
        {
            using (var command = sqlConnection.CreateCommand())
            {
                command.CommandText = "drop table " + tableName;
                command.ExecuteNonQuery();
            }
        }

        private void CreateTable(string fileName)
        {
            using (var command = sqlConnection.CreateCommand())
            {
                command.CommandText = File.ReadAllText(sqlFilePath + fileName + ".sql");
                command.ExecuteNonQuery();
            }
        }

        private bool ExistTable(string tableName)
        {
            using (var command = sqlConnection.CreateCommand())
            {
                command.CommandText = "select count(*) as exist from sqlite_master where type = 'table' and name = @tn";
                command.Parameters.Add(new SqliteParameter("tn", tableName));
                var result = command.ExecuteScalar();
                return (System.Int64)result == 1;
            }
        }
    }
}
