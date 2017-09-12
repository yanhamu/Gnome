using Gnome.Core.Model;
using MediatR;
using System;

namespace Gnome.Api.Services.Expressions.Requests
{
    public class GetExpression : IRequest<Expression>
    {
        public Guid ExpressionId { get; }

        public GetExpression(Guid expressionId)
        {
            this.ExpressionId = expressionId;
        }
    }
}
