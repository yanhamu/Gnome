using System;
using Gnome.Core.Model.Database;
using MediatR;

namespace Gnome.Api.Services.Queries.Requests
{
    public class CreateQuery : IRequest<Model>
    {
        public Guid UserId { get; set; }
    }
}
