using Autofac;
using Autofac.Extensions.DependencyInjection;
using Gnome.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Gnome.Api.Configuration
{
    public static class DiConfiguration
    {
        public const string SqlConnectionString = "Data Source=TOM-LENOVO\\SQLEXPRESS;Initial Catalog=gnome;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static IContainer CreateContainer(IServiceCollection services)
        {
            var containerBuilder = ContainerInitializer.CreateContainer();

            containerBuilder.Populate(services);
            return containerBuilder.Build();
        }
    }
}
