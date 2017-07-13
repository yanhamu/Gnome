using Autofac;
using Gnome.Core.DataAccess;
using Gnome.Core.Service;
using Gnome.Core.Service.Interfaces;

namespace Gnome.Infrastructure
{
    public class ContainerInitializer
    {
        public static ContainerBuilder CreateContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<UserSecurityService>();

            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<AccountService>().As<IAccountService>();
            builder.RegisterType<FioTransactionService>().As<ITransactionService>();

            builder.RegisterType<Core.Reports.AggregateReport.Service>();

            builder.RegisterType<UserRepository>();
            builder.RegisterType<UserSecurityRepository>();
            builder.RegisterType<FioAccountRepository>();
            builder.RegisterType<FioTransactionRepository>();

            return builder;
        }
    }
}
