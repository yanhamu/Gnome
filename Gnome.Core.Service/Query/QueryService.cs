using Gnome.Core.DataAccess;
using Gnome.Core.Model;
using System;
using System.Threading.Tasks;

namespace Gnome.Core.Service.Query
{
    public class QueryService : IQueryService
    {
        private readonly IQueryRepository queryRepository;
        private readonly IQueryDataService queryDataService;

        public QueryService(IQueryRepository queryRepository, IQueryDataService queryDataService)
        {
            this.queryRepository = queryRepository;
            this.queryDataService = queryDataService;
        }

        public async Task<QueryModel> Get(Guid queryId)
        {
            var query = await queryRepository.Find(queryId);
            var data = queryDataService.Deserialize(query.Data);

            return new QueryModel()
            {
                Accounts = data.Accounts,
                ExcludeExpressions = data.ExcludeExpressions,
                IncludeExpressions = data.IncludeExpressions,
                Name = query.Name,
                QueryId = query.Id
            };
        }
        public QueryModel Get(Gnome.Core.Model.Database.Query query)
        {
            var data = queryDataService.Deserialize(query.Data);
            return new QueryModel()
            {
                Accounts = data.Accounts,
                ExcludeExpressions = data.ExcludeExpressions,
                IncludeExpressions = data.IncludeExpressions,
                Name = query.Name,
                QueryId = query.Id
            };
        }
    }
}
