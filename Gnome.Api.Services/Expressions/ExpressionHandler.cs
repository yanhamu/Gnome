using Gnome.Api.Services.Expressions.Requests;
using Gnome.Core.DataAccess;
using Gnome.Core.Model;
using Gnome.Core.Service.RulesEngine.AST;
using MediatR;
using System;

namespace Gnome.Api.Services.Expressions
{
    public class ExpressionHandler :
        IRequestHandler<GetExpression, Expression>,
        IRequestHandler<CreateExpression, Guid>,
        IRequestHandler<UpdateExpression>,
        IRequestHandler<RemoveExpression>
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

        public Guid Handle(CreateExpression message)
        {
            var id = Guid.NewGuid();
            this.repository.Create(new Expression()
            {
                ExpressionString = message.Expression,
                Id = id,
                UserId = message.UserId,
                Name = message.Name ?? GetName()
            });
            repository.Save();
            return id;
        }

        public void Handle(UpdateExpression message)
        {
            var expression = repository.Find(message.ExpressionId);
            expression.ExpressionString = message.Expression;
            repository.Save();
        }

        public void Handle(RemoveExpression message)
        {
            repository.Remove(message.ExpressionId);
            repository.Save();
        }

        private string GetName()
        {
            var date = DateTime.UtcNow;
            return $"expr-{date.Year}-{date.Month}-{date.Day}/{date.Hour}:{date.Minute}:{date.Second}";
        }
    }
}