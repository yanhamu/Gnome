using Gnome.Api.Services.Expressions.Model;
using MediatR;
using System;
using System.Collections.Generic;

namespace Gnome.Api.Services.Expressions.Requests
{
    public class ListExpression : IRequest<List<Expression>>
    {
        public Guid UserId { get; }
        public ListExpression(Guid userId)
        {
            this.UserId = userId;
        }
    }
}
