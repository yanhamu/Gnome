using Gnome.Core.Model;
using System;

namespace Gnome.Core.Service.Query
{
    public interface IQueryService
    {
        QueryModel Get(Guid queryId);
        QueryModel Get(Gnome.Core.Model.Database.Query query);
    }
}