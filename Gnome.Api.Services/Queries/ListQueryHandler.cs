using Gnome.Api.Services.Queries.Requests;
using Gnome.Core.DataAccess;
using Gnome.Core.Service.Query;
using MediatR;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Api.Services.Queries
{
    public class ListQueryHandler : IRequestHandler<ListQueries, List<Model>>
    {
        private readonly IQueryRepository repository;
        private readonly IQueryDataService service;

        public ListQueryHandler(IQueryRepository queryRepository, IQueryDataService service)
        {
            this.repository = queryRepository;
            this.service = service;
        }

        public List<Model> Handle(ListQueries message)
        {
            var list = repository
                .Query
                .Where(q => q.UserId == message.UserId)
                .ToList()
                .Select(m => new
                {
                    model = service.Deserialize(m.Data),
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
