using Microsoft.Data.Sqlite;
using System.IO;

namespace Gnome.Database
{
    public class Initializer
    {
        private readonly SqliteConnection sqlConnection;

        public Initializer(SqliteConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }

        public void Initialize()
        {
            CreateTable("user");
        }

        private void CreateTable(string fileName)
        {
            using (var command = sqlConnection.CreateCommand())
            {
                command.CommandText = File.ReadAllText("bin\\Debug\\netcoreapp1.1\\sql-files\\" + fileName + ".sql");
                command.ExecuteNonQuery();
            }
        }
    }
}
