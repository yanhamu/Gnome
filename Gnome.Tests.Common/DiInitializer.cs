using Autofac;
using MongoDB.Driver;
using System.Data.SqlClient;

namespace Gnome.Tests.Common
{
    public class DiInitializer
    {
        public static IContainer BuildContainer()
        {
            var containerBuilder = Infrastructure.ContainerInitializer.CreateContainer();

            containerBuilder.Register(c => new SqlConnection(Database.ConnectionString));
            containerBuilder.Register<IMongoDatabase>(c =>
            {
                return new MongoClient().GetDatabase("fioDb");
            });

            return containerBuilder.Build();
        }
    }
}
