using Autofac;
using Autofac.Extensions.DependencyInjection;
using Gnome.Core.DataAccess;
using Gnome.Infrastructure;
using MediatR;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Reflection;

namespace Gnome.Api.IntegrationTests.Configuration
{
    public static class DiConfiguration
    {
        public static IContainer CreateContainer(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json")
                .Build();

            services.AddMediatR(CoreServiceAssembly);

            services.AddDbContext<GnomeDb>((p, b) =>
            {
                var connection = p.GetService<SqliteConnection>();
                b.UseSqlite(connection);
            });

            var containerBuilder = ContainerInitializer.CreateContainer(configuration);

            containerBuilder.Populate(services);
            return containerBuilder.Build();
        }

        private static Assembly CoreServiceAssembly => typeof(Services.Users.RegisterUser)
            .GetTypeInfo()
            .Assembly;
    }
}
