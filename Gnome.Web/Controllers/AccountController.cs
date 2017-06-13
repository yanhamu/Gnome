using Gnome.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Gnome.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        public IActionResult Index()
        {
            var userId = int.Parse(HttpContext.User.FindFirst("UserId").Value);
            return View(accountService.GetAccounts(userId));
        }
    }
}
