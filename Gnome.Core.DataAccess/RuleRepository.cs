using Gnome.Core.Model.Database;

namespace Gnome.Core.DataAccess
{
    public interface IRuleRepository : IGenericRepository<Rule> { }

    public class RuleRepository : GenericRepository<Rule>, IRuleRepository
    {
        public RuleRepository(GnomeDb context) : base(context) { }
    }
}
