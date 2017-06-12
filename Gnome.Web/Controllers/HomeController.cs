using Microsoft.AspNetCore.Mvc;

namespace Gnome.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
