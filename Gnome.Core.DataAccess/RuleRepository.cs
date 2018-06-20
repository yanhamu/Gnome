using Gnome.Core.Model.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gnome.Core.DataAccess
{
    public interface IRuleRepository : IGenericRepository<Rule>
    {
        Task<List<Rule>> GetRules(Guid userId);
    }

    public class RuleRepository : GenericRepository<Rule>, IRuleRepository
    {
        public RuleRepository(GnomeDb context) : base(context) { }
        public Task<List<Rule>> GetRules(Guid userId)
        {
            return this.Query.Where(r => r.UserId == userId).ToListAsync();
        }
    }
}
