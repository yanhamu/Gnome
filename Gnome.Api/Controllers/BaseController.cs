using Microsoft.AspNetCore.Mvc;
using System;

namespace Gnome.Api.Controllers
{
    public class BaseController : Controller
    {
        public Guid UserId { get { return Guid.Parse(HttpContext.User.FindFirst("user_id").Value); } }
    }
}
