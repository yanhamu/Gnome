using Microsoft.AspNetCore.Mvc;

namespace Gnome.Web.Extensions
{
    public class BaseController : Controller
    {
        public int UserId { get { return int.Parse(HttpContext.User.FindFirst("UserId").Value); } }
    }
}
