using Autofac;
using Autofac.Extensions.DependencyInjection;
using Gnome.Infrastructure;
using Gnome.Web.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Data.SqlClient;

namespace Gnome.Web.Configuration
{
    public static class DiConfiguration
    {
        public const string SqlConnectionString = "Data Source=TOM-LENOVO\\SQLEXPRESS;Initial Catalog=gnome;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static IContainer CreateContainer(IServiceCollection services)
        {
            var containerBuilder = ContainerInitializer.CreateContainer();

            containerBuilder.Register(c => new SqlConnection(SqlConnectionString));

            containerBuilder.RegisterType<AuthenticationService>().As<IAuthenticationService>();

            containerBuilder.Populate(services);
            return containerBuilder.Build();
        }
    }
}