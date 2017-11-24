using Gnome.Core.Model.Database;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Core.DataAccess
{
    public interface IRuleRepository : IGenericRepository<Rule>
    {
        List<Rule> GetRules(Guid userId);
    }

    public class RuleRepository : GenericRepository<Rule>, IRuleRepository
    {
        public RuleRepository(GnomeDb context) : base(context) { }
        public List<Rule> GetRules(Guid userId)
        {
            return this.Query.Where(r => r.UserId == userId).ToList();
        }
    }
}
