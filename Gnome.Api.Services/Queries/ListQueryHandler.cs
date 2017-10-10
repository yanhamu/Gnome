using Gnome.Api.Services.Queries.Requests;
using Gnome.Core.DataAccess;
using Gnome.Core.Model;
using Gnome.Core.Service.Query;
using MediatR;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Api.Services.Queries
{
    public class ListQueryHandler : IRequestHandler<ListQueries, List<QueryModel>>
    {
        private readonly IQueryRepository repository;
        private readonly IQueryService queryService;

        public ListQueryHandler(
            IQueryRepository queryRepository,
            IQueryService queryService)
        {
            this.repository = queryRepository;
            this.queryService = queryService;
        }

        public List<QueryModel> Handle(ListQueries message)
        {
            return repository
                .Query
                .Where(q => q.UserId == message.UserId)
                .ToList()
                .Select(m => queryService.Get(m))
                .ToList();
        }
    }
}
