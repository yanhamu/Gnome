using MediatR;
using System;

namespace Gnome.Api.Services.Expressions.Requests
{
    public class CreateExpression : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Expression { get; set; }
    }
}
