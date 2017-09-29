using Gnome.Api.Services.Users;
using StructureMap;

namespace Gnome.Infrastructure
{
    public class ApiServiceRegistry : Registry
    {
        public ApiServiceRegistry()
        {
            Scan(_ =>
            {
                _.AssemblyContainingType<RegisterUser>();
                _.Include(t => t.Name.EndsWith("Service"));
                _.Include(t => t.Name.EndsWith("Factory"));
                _.WithDefaultConventions();
            });
        }
    }
}
