using Gnome.Api.Services.Queries.Requests;
using Gnome.Core.DataAccess;
using Gnome.Core.Model;
using Gnome.Core.Service.Query;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Gnome.Api.Services.Queries
{
    public class UpdateQueryHandler : IRequestHandler<UpdateQuery, QueryModel>
    {
        private readonly IQueryRepository repository;
        private readonly IQueryDataService service;

        public UpdateQueryHandler(IQueryRepository queryRepository, IQueryDataService queryDataservice)
        {
            this.repository = queryRepository;
            this.service = queryDataservice;
        }

        public async Task<QueryModel> Handle(UpdateQuery message, CancellationToken cancellationToken)
        {
            var query = await repository.Find(message.Id);
            var data = new QueryData(message.ExcludeExpressions, message.IncludeExpressions, message.Accounts);
            query.Data = service.Serialize(data);
            query.Name = message.Name;
            await repository.Save();

            return new QueryModel()
            {
                Accounts = message.Accounts,
                Name = query.Name,
                ExcludeExpressions = data.ExcludeExpressions,
                IncludeExpressions = data.IncludeExpressions,
                QueryId = query.Id
            };
        }
    }
}