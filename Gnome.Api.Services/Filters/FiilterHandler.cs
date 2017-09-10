using Gnome.Api.Services.Filters.Requests;
using Gnome.Core.DataAccess;
using Gnome.Core.Model;
using MediatR;

namespace Gnome.Api.Services.Filters
{
    public class FiilterHandler : IRequestHandler<GetFilter, Filter>
    {
        private readonly IFilterRepository filterRepository;

        public FiilterHandler(IFilterRepository filterRepository)
        {
            this.filterRepository = filterRepository;
        }

        public Filter Handle(GetFilter message)
        {
            return filterRepository.Find(message.FilterId);
        }
    }
}
