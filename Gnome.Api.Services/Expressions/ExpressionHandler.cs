using Gnome.Api.Services.Expressions.Requests;
using Gnome.Core.DataAccess;
using Gnome.Core.Model.Database;
using Gnome.Core.Service.RulesEngine.AST;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Api.Services.Expressions
{
    public class ExpressionHandler :
        IRequestHandler<GetExpression, Expression>,
        IRequestHandler<CreateExpression, Model.Expression>,
        IRequestHandler<UpdateExpression>,
        IRequestHandler<RemoveExpression>,
        IRequestHandler<ListExpression, List<Model.Expression>>
    {
        private readonly IExpressionRepository repository;
        private readonly SyntaxTreeBuilderFacade treeBuilderFacade;

        public ExpressionHandler(SyntaxTreeBuilderFacade treeBuilderFacade)
        {
            this.treeBuilderFacade = treeBuilderFacade;
        }

        public ExpressionHandler(IExpressionRepository filterRepository)
        {
            this.repository = filterRepository;
        }

        public Expression Handle(GetExpression message)
        {
            return repository.Find(message.ExpressionId);
        }

        public Model.Expression Handle(CreateExpression message)
        {
            var id = Guid.NewGuid();
            var expression = this.repository.Create(new Expression()
            {
                ExpressionString = message.Expression,
                Id = id,
                UserId = message.UserId,
                Name = message.Name ?? GetName()
            });
            repository.Save();

            return new Model.Expression()
            {
                Id = expression.Id,
                ExpressionString = expression.ExpressionString,
                Name = expression.Name
            };
        }

        public void Handle(UpdateExpression message)
        {
            var expression = repository.Find(message.Id);
            expression.ExpressionString = message.ExpressionString;
            repository.Save();
        }

        public void Handle(RemoveExpression message)
        {
            repository.Remove(message.ExpressionId);
            repository.Save();
        }

        public List<Model.Expression> Handle(ListExpression message)
        {
            return repository
                .Query
                .Where(e => e.UserId == message.UserId)
                .Select(e => new Model.Expression()
                {
                    ExpressionString = e.ExpressionString,
                    Id = e.Id,
                    Name = e.Name
                })
                .ToList();
        }

        private string GetName()
        {
            var date = DateTime.UtcNow;
            return $"expr-{date.Year}-{date.Month}-{date.Day}/{date.Hour}:{date.Minute}:{date.Second}";
        }
    }
}