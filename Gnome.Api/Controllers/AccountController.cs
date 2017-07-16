using Gnome.Api.Services.Accounts;
using Microsoft.AspNetCore.Mvc;

namespace Gnome.Api.Controllers
{
    [Route("api/accounts")]
    public class AccountController : BaseController
    {
        private readonly AccountService accountService;

        public AccountController(AccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpGet()]
        public IActionResult List()
        {
            return new OkObjectResult(accountService.List(UserId));
        }

        [HttpGet("{accountId:int}")]
        public IActionResult Get(int accountId)
        {
            return new OkObjectResult(accountService.Get(accountId));
        }

        [HttpPut("{accountId:int}")]
        public IActionResult Update(int accountId, [FromBody]Account account)
        {
            return new OkObjectResult(accountService.Update(account));
        }

        [HttpPost()]
        public IActionResult Create([FromBody]Account account)
        {
            return new OkObjectResult(accountService.Create(account, UserId));
        }
    }
}
