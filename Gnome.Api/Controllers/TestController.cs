using Microsoft.AspNetCore.Mvc;

namespace Gnome.Api.Controllers
{
    [Route("api")]
    public class TestController : Controller
    {
        [HttpGet("test")]
        public IActionResult Test()
        {
            return new OkResult();
        }
    }
}
