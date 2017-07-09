using Autofac;
using Autofac.Extensions.DependencyInjection;
using Gnome.Core.DataAccess;
using Gnome.Infrastructure;
using Gnome.Web.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data.SqlClient;
using System.IO;

namespace Gnome.Web.Configuration
{
    public static class DiConfiguration
    {
        public static IContainer CreateContainer(IServiceCollection services)
        {
            var containerBuilder = ContainerInitializer.CreateContainer();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("ConnectionStrings.json")
                .Build();

            services.AddDbContext<GnomeDb>(c => c.UseSqlServer(configuration["db:dev"]));
            containerBuilder.Register(c => new SqlConnection(configuration["db:dev"]));
            containerBuilder.RegisterType<AuthenticationService>()
                .As<IAuthenticationService>();

            containerBuilder.Populate(services);
            return containerBuilder.Build();
        }
    }
}