using Gnome.Api.Services.Queries.Requests;
using Gnome.Core.DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Api.Services.Queries
{
    public class ListQueryHandler : QueryHandler<ListQueries, List<Model>>
    {
        public ListQueryHandler(IQueryRepository queryRepository) : base(queryRepository) { }

        public override List<Model> Handle(ListQueries message)
        {
            var list = repository
                .Query
                .Where(q => q.UserId == message.UserId)
                .ToList()
                .Select(m => new
                {
                    model = Deserialize(m.Data),
                    id = m.Id,
                    name = m.Name
                })
                .Select(q => new Model()
                {
                    Accounts = q.model.Accounts,
                    ExcludeExpressions = q.model.ExcludeExpressions,
                    IncludeExpressions = q.model.IncludeExpressions,
                    Name = q.name,
                    QueryId = q.id
                }).ToList()
                ;
            return list;
        }
    }
}
