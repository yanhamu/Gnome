using MediatR;
using System;

namespace Gnome.Api.Services.Expressions.Requests
{
    public class UpdateExpression : IRequest
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string ExpressionString { get; set; }
        public Guid Id { get; set; }
    }
}
