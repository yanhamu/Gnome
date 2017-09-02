using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.IO;

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

        public void Initialize()
        {
            createTableFiles.ForEach(f => CreateTable(f));
        }

        private void CreateTable(string fileName)
        {
            using (var command = sqlConnection.CreateCommand())
            {
                command.CommandText = File.ReadAllText(sqlFilePath + fileName + ".sql");
                command.ExecuteNonQuery();
            }
        }
    }
}
