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
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Gnome.Api.Configuration
{
    public static class DiConfiguration
    {
        public static IContainer CreateContainer(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json")
                .Build();

            services.AddDbContext<GnomeDb>(c => c.UseSqlite(configuration["db:dev"]));
            services.AddMediatR(CoreServiceAssembly);

            var containerBuilder = ContainerInitializer.CreateContainer();
            containerBuilder.Register(c =>
            {
                var connection = new SqliteConnection(configuration["db:dev"]);
                connection.Open();
                return connection;
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
                .WithParameter("sqlFilePath", configuration["db:dev"])
                .WithParameter("tableNames", new List<string>() {
                    "user",
                    "fio_account",
                    "category",
                    "transaction",
                    "category_transaction",
                    "expression"
                });

            containerBuilder.Populate(services);
            return containerBuilder.Build();
        }

        private static Assembly CoreServiceAssembly => typeof(Gnome.Api.Services.Users.RegisterUser).GetTypeInfo().Assembly;

    }
}