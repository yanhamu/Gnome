using MediatR;
using System;

namespace Gnome.Api.Services.Expressions.Requests
{
    public class UpdateExpression : IRequest
    {
        public Guid UserId { get; set; }
        public string Expression { get; set; }
        public Guid ExpressionId { get; set; }
    }
}
