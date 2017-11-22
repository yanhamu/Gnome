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

        public Initializer(
            SqliteConnection sqlConnection,
            string sqlFilePath,
            List<string> tableNames)
        {
            this.sqlConnection = sqlConnection;
            this.sqlFilePath = sqlFilePath;
            this.createTableFiles = tableNames;
        }

        public bool HasAllTables()
        {
            return createTableFiles.All(t => ExistTable(t));
        }

        public void DropAndCreate()
        {
            createTableFiles
                .AsEnumerable()
                .Reverse()
                .Where(f => ExistTable(f))
                .ToList()
                .ForEach(f => DropTable(f));

            EnableForeignKeys();

            createTableFiles
                .ForEach(f => CreateTable(f));
        }

        private void EnableForeignKeys()
        {
            using (var command = sqlConnection.CreateCommand())
            {
                command.CommandText = "PRAGMA foreign_keys = ON";
                command.ExecuteNonQuery();
            }
        }

        private void DropTable(string tableName)
        {
            using (var command = sqlConnection.CreateCommand())
            {
                command.CommandText = $"drop table [{tableName}]";
                command.ExecuteNonQuery();
            }
        }

        private void CreateTable(string fileName)
        {
            using (var command = sqlConnection.CreateCommand())
            {
                var absoluteSqlFilePath = Path.Combine(
                    sqlFilePath,
                    fileName + ".sql");

                command.CommandText = File.ReadAllText(absoluteSqlFilePath);
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
