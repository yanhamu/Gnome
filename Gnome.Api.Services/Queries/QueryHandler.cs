using Gnome.Core.DataAccess;
using Gnome.Core.Model;
using MediatR;
using Newtonsoft.Json;

namespace Gnome.Api.Services.Queries
{
    public abstract class QueryHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        protected readonly IQueryRepository repository;

        public QueryHandler(IQueryRepository queryRepository)
        {
            this.repository = queryRepository;
        }

        public string Serialize(QueryData data) => JsonConvert.SerializeObject(data);
        public QueryData Deserialize(string data) => JsonConvert.DeserializeObject<QueryData>(data);
        public abstract TResponse Handle(TRequest message);
    }
}
