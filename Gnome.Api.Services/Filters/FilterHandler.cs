using Gnome.Api.Services.Filters.Requests;
using Gnome.Core.DataAccess;
using Gnome.Core.Model;
using Gnome.Core.Service.RulesEngine.AST;
using MediatR;
using System;

namespace Gnome.Api.Services.Filters
{
    public class FiilterHandler :
        IRequestHandler<GetFilter, Filter>,
        IRequestHandler<CreateFilter, Guid>,
        IRequestHandler<UpdateFilter>,
        IRequestHandler<RemoveFilter>
    {
        private readonly IFilterRepository repository;
        private readonly SyntaxTreeBuilderFacade treeBuilderFacade;

        public FiilterHandler(SyntaxTreeBuilderFacade treeBuilderFacade)
        {
            this.treeBuilderFacade = treeBuilderFacade;
        }

        public FiilterHandler(IFilterRepository filterRepository)
        {
            this.repository = filterRepository;
        }

        public Filter Handle(GetFilter message)
        {
            return repository.Find(message.FilterId);
        }

        public Guid Handle(CreateFilter message)
        {
            var id = Guid.NewGuid();
            this.repository.Create(new Filter()
            {
                Expression = message.Expression,
                Id = id,
                UserId = message.UserId
            });
            repository.Save();
            return id;
        }

        public void Handle(UpdateFilter message)
        {
            var filter = repository.Find(message.FilterId);
            filter.Expression = message.Expression;
            repository.Save();
        }

        public void Handle(RemoveFilter message)
        {
            repository.Remove(message.FilterId);
            repository.Save();
        }
    }
}