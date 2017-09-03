using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Features.Variance;
using Gnome.Core.DataAccess;
using Gnome.Database;
using Gnome.Infrastructure;
using MediatR;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Reflection;

namespace Gnome.Api.IntegrationTests
{
    public static class DiConfiguration
    {
        public static IContainer CreateContainer(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("ConnectionStrings.json")
                .Build();

            services.AddMediatR(CoreServiceAssembly);

            var containerBuilder = ContainerInitializer.CreateContainer();
            containerBuilder.Register(c =>
            {
                var connection = new SqliteConnection(configuration["db:dev"]);
                connection.Open();
                return connection;
            }).SingleInstance();

            services.AddDbContext<GnomeDb>((p, b) =>
            {
                var connection = p.GetService<SqliteConnection>();
                b.UseSqlite(connection);
            });

            containerBuilder.RegisterSource(new ContravariantRegistrationSource());

            containerBuilder.RegisterAssemblyTypes(CoreServiceAssembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();

            containerBuilder.RegisterAssemblyTypes(CoreServiceAssembly)
                .Where(t => t.Name.EndsWith("Factory"))
                .AsImplementedInterfaces();

            containerBuilder
                .RegisterType<Initializer>()
                .AsSelf()
                .WithParameter("sqlFilePath", "sql-files\\");

            containerBuilder.Populate(services);
            return containerBuilder.Build();
        }

        private static Assembly CoreServiceAssembly => typeof(Gnome.Api.Services.Users.RegisterUser).GetTypeInfo().Assembly;
    }
}
