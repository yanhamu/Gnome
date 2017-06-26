using Autofac;
using System.Data.SqlClient;

namespace Gnome.Tests.Common
{
    public class DiInitializer
    {
        public static IContainer BuildContainer()
        {
            var containerBuilder = Infrastructure.ContainerInitializer.CreateContainer();

            containerBuilder.Register(c => new SqlConnection(Database.ConnectionString));

            return containerBuilder.Build();
        }
    }
}
