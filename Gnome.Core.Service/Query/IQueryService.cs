using Gnome.Core.Model;
using System;
using System.Threading.Tasks;

namespace Gnome.Core.Service.Query
{
    public interface IQueryService
    {
        Task<QueryModel> Get(Guid queryId);
        QueryModel Get(Gnome.Core.Model.Database.Query query);
    }
}