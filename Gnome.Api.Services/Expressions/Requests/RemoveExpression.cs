using MediatR;
using System;

namespace Gnome.Api.Services.Expressions.Requests
{
    public class RemoveExpression : IRequest
    {
        public Guid ExpressionId { get; set; }
    }
}
