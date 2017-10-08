using Gnome.Database;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using StructureMap;
using System.Collections.Generic;

namespace Gnome.Infrastructure
{
    public class ContainerInitializer
    {
        public static Container CreateContainer(IConfigurationRoot configuration)
        {
            var registry = new Registry();
            registry.IncludeRegistry<DataAccessRegistry>();
            registry.IncludeRegistry<CoreServiceRegistry>();
            registry.IncludeRegistry<ReportingRegistry>();
            registry.IncludeRegistry<ApiServiceRegistry>();
            registry
                .For<SqliteConnection>()
                .Use("Creating new Sqlite connection", c =>
                 {
                     var connection = new SqliteConnection(configuration["db:core"]);
                     connection.Open();
                     using (var command = connection.CreateCommand())
                     {
                         command.CommandText = "PRAGMA foreign_keys = ON";
                         command.ExecuteNonQuery();
                     }
                     return connection;
                 })
                 .Singleton();

            registry.For<Initializer>()
                .Use<Initializer>()
                .Ctor<string>("sqlFilePath").Is(c => configuration["sql"])
                .Ctor<List<string>>("tableNames").Is(new List<string>() {
                                "user",
                                "account",
                                "category",
                                "transaction",
                                "category_transaction",
                                "expression",
                                "filter",
                                "query",
                                "report"
                });

            return new Container(registry);
        }
    }
}
