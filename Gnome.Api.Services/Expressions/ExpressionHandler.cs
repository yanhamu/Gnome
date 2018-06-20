using Gnome.Api.Services.Expressions.Requests;
using Gnome.Core.DataAccess;
using Gnome.Core.Model.Database;
using Gnome.Core.Service.RulesEngine.AST;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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
        private readonly ISyntaxTreeBuilderFacade treeBuilderFacade;

        public ExpressionHandler(
            IExpressionRepository filterRepository,
            ISyntaxTreeBuilderFacade treeBuilderFacade)
        {
            this.repository = filterRepository;
            this.treeBuilderFacade = treeBuilderFacade;
        }

        public async Task<Expression> Handle(GetExpression message, CancellationToken cancellationToken)
        {
            return await repository.Find(message.ExpressionId);
        }

        public async Task<Model.Expression> Handle(CreateExpression message, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();
            var expression = this.repository.Create(new Expression()
            {
                ExpressionString = message.Expression,
                Id = id,
                UserId = message.UserId,
                Name = message.Name ?? GetName()
            });
            await repository.Save();

            return new Model.Expression()
            {
                Id = expression.Id,
                ExpressionString = expression.ExpressionString,
                Name = expression.Name
            };
        }

        public async Task<Unit> Handle(UpdateExpression message, CancellationToken cancellationToken)
        {
            var expression = await repository.Find(message.Id);
            expression.ExpressionString = message.ExpressionString;
            expression.Name = message.Name;
            await repository.Save();
            return Unit.Value;
        }

        public async Task<Unit> Handle(RemoveExpression message, CancellationToken cancellationToken)
        {
            repository.Remove(message.ExpressionId);
            await repository.Save();
            return Unit.Value;
        }

        public Task<List<Model.Expression>> Handle(ListExpression message, CancellationToken cancellationToken)
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
                .ToListAsync();
        }

        private string GetName()
        {
            var date = DateTime.UtcNow;
            return $"expr-{date.Year}-{date.Month}-{date.Day}/{date.Hour}:{date.Minute}:{date.Second}";
        }
    }
}