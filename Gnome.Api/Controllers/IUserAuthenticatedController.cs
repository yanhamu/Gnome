using System;

namespace Gnome.Api.Controllers
{
    public interface IUserAuthenticatedController
    {
        Guid UserId { get; set; }
    }
}
