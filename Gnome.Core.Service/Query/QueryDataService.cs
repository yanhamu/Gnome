using Gnome.Core.Model;
using Newtonsoft.Json;

namespace Gnome.Core.Service.Query
{
    public class QueryDataService : IQueryDataService
    {
        public string Serialize(QueryData data) => JsonConvert.SerializeObject(data);
        public QueryData Deserialize(string data) => JsonConvert.DeserializeObject<QueryData>(data);
    }
}