using Gnome.Api.Services.Accounts;
using Gnome.Api.Services.Accounts.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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
        public async Task<IActionResult> List()
        {
            return new OkObjectResult(await mediator.Send(new ListUserAccounts(UserId)));
        }

        [HttpGet("{accountId:Guid}")]
        public async Task<IActionResult> Get(Guid accountId)
        {
            return new OkObjectResult(await mediator.Send(new GetAccount(accountId)));
        }

        [HttpPut("{accountId:Guid}")]
        public async Task<IActionResult> Update(Guid accountId, [FromBody]Account account)
        {
            return new OkObjectResult(await mediator.Send(new UpdateAccount(accountId, account.Name, account.Token)));
        }

        [HttpPost()]
        public async Task<IActionResult> Create([FromBody]Account account)
        {
            return new OkObjectResult(await mediator.Send(new CreateAccount(UserId, account.Token, account.Name)));
        }

        [HttpDelete("{accountId:Guid}")]
        public async Task<IActionResult> Remove(Guid accountId)
        {
            await mediator.Publish(new RemoveAccount(accountId));
            return new NoContentResult();
        }
    }
}
