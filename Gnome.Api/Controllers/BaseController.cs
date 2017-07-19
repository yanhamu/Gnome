using Microsoft.AspNetCore.Mvc;

namespace Gnome.Api.Controllers
{
    public class BaseController : Controller
    {
        public int UserId { get { return int.Parse(HttpContext.User.FindFirst("user_id").Value); } }
    }
}
