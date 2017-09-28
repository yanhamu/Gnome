using Gnome.Api.Filters;
using Gnome.Api.Services.Transactions.Requests;
using Gnome.Core.Service.Search.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Gnome.Api.Controllers
{
    [Route("api")]
    public class TransactionController : IUserAuthenticatedController
    {
        private readonly IMediator mediator;
        public Guid UserId { get; set; }

        public TransactionController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("accounts/{accountId:Guid}/transactions")]
        public async Task<IActionResult> Search(Guid accountId, [FromBody] SingleAccountTransactionSearchFilter filter)
        {
            filter.AccountId = accountId;

            return new OkObjectResult(await mediator.Send(new SingleAccountSearchTransaction(filter, UserId)));
        }

        [HttpGet("transactions")]
        public async Task<IActionResult> FilterTransactions(MultiAccountTransactionSearchFilter filter)
        {
            return new OkObjectResult(await mediator.Send(new MultiAccountSearchTransaction(UserId, filter)));
        }

        [IgnoreUserFilter]
        [HttpPost("transactions")]
        public async Task<IActionResult> CreateTransaction([FromBody] CreateTransaction transaction)
        {
            return new OkObjectResult(await mediator.Send(transaction));
        }
    }
}