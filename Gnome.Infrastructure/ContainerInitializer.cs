using Autofac;
using Autofac.Features.Variance;
using Gnome.Core.DataAccess;
using Gnome.Core.Service;
using Gnome.Database;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Extensions;

namespace Gnome.Infrastructure
{
    public class ContainerInitializer
    {
        public static ContainerBuilder CreateContainer(IConfigurationRoot configuration)
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(CoreServiceAssembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(CoreServiceAssembly)
                .Where(t => t.Name.EndsWith("Factory"))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(CoreServiceAssembly)
                .Where(t => t.Name.EndsWith("Builder"))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(CoreReportAssembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(CoreRepositoryAssembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();

            builder.Register(c =>
            {
                var connection = new SqliteConnection(configuration["db:core"]);
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "PRAGMA foreign_keys = ON";
                    command.ExecuteNonQuery();
                }
                return connection;
            }).SingleInstance();

            builder.RegisterSource(new ContravariantRegistrationSource());

            builder
                .RegisterType<Initializer>()
                .AsSelf()
                .WithParameter("sqlFilePath", configuration["sql"])
                .WithParameter("tableNames", new List<string>() {
                                "user",
                                "account",
                                "category",
                                "transaction",
                                "category_transaction",
                                "expression"
                });

            builder.RegisterAssemblyTypes(CoreApiServiceAssembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(CoreApiServiceAssembly)
                .Where(t => t.Name.EndsWith("Factory"))
                .AsImplementedInterfaces();

            return builder;
        }

        private static Assembly CoreReportAssembly { get { return typeof(Core.Reports.AggregateReport.IAggregateReportService).GetTypeInfo().Assembly; } }

        private static Assembly CoreServiceAssembly { get { return typeof(UserSecurityService).GetTypeInfo().Assembly; } }

        private static Assembly CoreRepositoryAssembly { get { return typeof(IUserRepository).GetTypeInfo().Assembly; } }

        private static Assembly CoreApiServiceAssembly => typeof(Gnome.Api.Services.Users.RegisterUser).GetTypeInfo().Assembly;

    }
}
