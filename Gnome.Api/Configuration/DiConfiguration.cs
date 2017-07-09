using Autofac;
using Autofac.Extensions.DependencyInjection;
using Gnome.Core.DataAccess;
using Gnome.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace Gnome.Api.Configuration
{
    public static class DiConfiguration
    {
        public const string SqlConnectionString = "Data Source=TOM-LENOVO\\SQLEXPRESS;Initial Catalog=gnome;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static IContainer CreateContainer(IServiceCollection services)
        {
            var containerBuilder = ContainerInitializer.CreateContainer();
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("ConnectionStrings.json")
                .Build();

            services.AddDbContext<GnomeDb>(c => c.UseSqlServer(configuration["db:dev"]));

            containerBuilder.Populate(services);
            return containerBuilder.Build();
        }
    }
}