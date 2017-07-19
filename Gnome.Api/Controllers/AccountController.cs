using Gnome.Api.Services.Accounts;
using Gnome.Api.Services.Accounts.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gnome.Api.Controllers
{
    [Route("api/accounts")]
    public class AccountController : BaseController
    {
        private readonly IMediator mediator;

        public AccountController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet()]
        public IActionResult List()
        {
            return new OkObjectResult(mediator.Send(new ListUserAccounts(UserId)));
        }

        [HttpGet("{accountId:int}")]
        public IActionResult Get(int accountId)
        {
            return new OkObjectResult(mediator.Send(new GetAccount(accountId)));
        }

        [HttpPut("{accountId:int}")]
        public IActionResult Update(int accountId, [FromBody]Account account)
        {
            var result = mediator.Send(new UpdateAccount(accountId, account.Name, account.Token));
            return new OkObjectResult(result);
        }

        [HttpPost()]
        public IActionResult Create([FromBody]Account account)
        {
            var result = mediator.Send(new CreateAccount(UserId, account.Token, account.Name));
            return new OkObjectResult(result);
        }
    }
}
