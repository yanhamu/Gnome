using Autofac;
using Gnome.Core.DataAccess;
using Gnome.Core.Service;
using System.Reflection;

namespace Gnome.Infrastructure
{
    public class ContainerInitializer
    {
        public static ContainerBuilder CreateContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(CoreServiceAssembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(CoreServiceAssembly)
                .Where(t => t.Name.EndsWith("Factory"))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(CoreReportAssembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(CoreRepositoryAssembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsSelf();

            return builder;
        }

        private static Assembly CoreReportAssembly { get { return typeof(Core.Reports.Interval).GetTypeInfo().Assembly; } }
        private static Assembly CoreServiceAssembly { get { return typeof(UserSecurityService).GetTypeInfo().Assembly; } }
        private static Assembly CoreRepositoryAssembly { get { return typeof(UserRepository).GetTypeInfo().Assembly; } }
    }
}
