using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Features.Variance;
using Gnome.Core.DataAccess;
using Gnome.Infrastructure;
using MediatR;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
                .AddJsonFile("ConnectionStrings.json")
                .Build();

            services.AddDbContext<GnomeDb>(c => c.UseSqlite(configuration["db:dev"]));
            services.AddMediatR(CoreServiceAssembly);

            var containerBuilder = ContainerInitializer.CreateContainer();
            containerBuilder.Register(c => new SqliteConnection(configuration["db:dev"]));
            containerBuilder.RegisterSource(new ContravariantRegistrationSource());

            containerBuilder.RegisterAssemblyTypes(CoreServiceAssembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();

            containerBuilder.RegisterAssemblyTypes(CoreServiceAssembly)
                .Where(t => t.Name.EndsWith("Factory"))
                .AsImplementedInterfaces();

            containerBuilder.Populate(services);
            return containerBuilder.Build();
        }

        private static Assembly CoreServiceAssembly => typeof(Gnome.Api.Services.Users.RegisterUser).GetTypeInfo().Assembly;

    }
}