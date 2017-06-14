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
        public IActionResult Detail(int id)
        {
            return View(accountService.Get(id));
        }


        [HttpPost]
        public IActionResult Edit(int accountId, [FromBody]Account account)
        {
            return View(accountService.Update(accountId, account));
        }

        [HttpGet]
        public IActionResult CreateNew()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateNew(Account account)
        {
            var newAccount = accountService.CreateNew(account);
            return Redirect("/Account/" + newAccount.Id);
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            accountService.Remove(id);
            return Redirect("/Account");
        }
    }
}
