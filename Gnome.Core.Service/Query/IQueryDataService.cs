using Gnome.Core.Model;

namespace Gnome.Core.Service.Query
{
    public interface IQueryDataService
    {
        QueryData Deserialize(string data);
        string Serialize(QueryData data);
    }
}