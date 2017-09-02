using Microsoft.Data.Sqlite;
using System.IO;

namespace Gnome.Database
{
    public class Initializer
    {
        private readonly SqliteConnection sqlConnection;
        private readonly string sqlFilePath;

        public Initializer(SqliteConnection sqlConnection, string sqlFilePath)
        {
            this.sqlConnection = sqlConnection;
            this.sqlFilePath = sqlFilePath;
        }

        public void Initialize()
        {
            CreateTable("user");
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
