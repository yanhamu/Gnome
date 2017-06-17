using Gnome.Web.Extensions;
using Gnome.Web.Model.ViewModel;
using Gnome.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Gnome.Web.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(accountService.GetAccounts(UserId));
        }

        [HttpGet]
        public IActionResult Settings(int id)
        {
            return View(accountService.Get(id));
        }

        [HttpPost]
        public IActionResult Settings(int id, Account account)
        {
            accountService.Update(id, account);
            return View(accountService.Get(account.Id));
        }


        [HttpPost]
        public IActionResult Edit(int accountId, [FromBody]Account account)
        {
            return View(accountService.Update(accountId, account));
        }

        [HttpPost]
        public IActionResult Index(Account account)
        {
            var id = accountService.CreateNew(account, UserId);
            return Redirect("/account/settings/" + id);
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            accountService.Remove(id);
            return Redirect("/Account");
        }
    }
}
