using System;
using Gnome.Core.Model.Database;
using MediatR;

namespace Gnome.Api.Services.Queries.Requests
{
    public class UpdateQuery : IRequest<Model>
    {
        public Guid Id { get; set; }
    }
}
