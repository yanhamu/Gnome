using Gnome.Api.Services.Queries.Requests;
using Gnome.Core.DataAccess;

namespace Gnome.Api.Services.Queries
{
    public class GetQueryHandler : QueryHandler<GetQuery, Model>
    {
        public GetQueryHandler(IQueryRepository queryRepository) : base(queryRepository) { }

        public override Model Handle(GetQuery message)
        {
            var result = repository.Find(message.QueryId);
            var data = Deserialize(result.Data);
            return new Model()
            {
                Accounts = data.Accounts,
                ExcludeExpressions = data.ExcludeExpressions,
                IncludeExpressions = data.IncludeExpressions,
                Name = result.Name,
                QueryId = result.Id
            };
        }
    }
}
