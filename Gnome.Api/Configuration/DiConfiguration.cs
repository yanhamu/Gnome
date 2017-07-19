using Autofac;
using Autofac.Extensions.DependencyInjection;
using Gnome.Core.DataAccess;
using Gnome.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data.SqlClient;
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

            services.AddDbContext<GnomeDb>(c => c.UseSqlServer(configuration["db:dev"]));
            services.AddMediatR(GetCoreServiceAssembly());

            var containerBuilder = ContainerInitializer.CreateContainer();
            containerBuilder.Register(c => new SqlConnection(configuration["db:dev"]));
            containerBuilder.RegisterType<Gnome.Api.Services.Users.RegisterUserHandler>();

            containerBuilder.Populate(services);
            return containerBuilder.Build();
        }

        private static Assembly GetCoreServiceAssembly()
        {
            return typeof(Gnome.Api.Services.Users.RegisterUser).GetTypeInfo().Assembly;
        }
    }
}