using Gnome.Core.DataAccess;
using StructureMap;

namespace Gnome.Infrastructure
{
    public class DataAccessRegistry : Registry
    {
        public DataAccessRegistry()
        {
            Scan(_ =>
            {
                _.AssemblyContainingType<IUserRepository>();
                _.Include(t => t.Name.EndsWith("Repository"));
                _.WithDefaultConventions();
            });
        }
    }
}
