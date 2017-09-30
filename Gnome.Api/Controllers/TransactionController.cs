using Gnome.Api.Filters;
using Gnome.Api.Services.Transactions.Requests;
using Gnome.Core.Service.Search.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

        [HttpPost("accounts/{accountId:Guid}/transactions/query")]
        public async Task<IActionResult> Search(Guid accountId, [FromBody] TransactionSearchFilter filter)
        {
            filter.Accounts = new List<Guid>() { accountId };

            return new OkObjectResult(await mediator.Send(new SearchTransaction(filter, UserId)));
        }

        [HttpPost("transactions/query")]
        public async Task<IActionResult> Search([FromBody] TransactionSearchFilter filter)
        {
            return new OkObjectResult(await mediator.Send(new SearchTransaction(filter, UserId)));
        }

        [IgnoreUserFilter]
        [HttpPost("transactions")]
        public async Task<IActionResult> CreateTransaction([FromBody] CreateTransaction transaction)
        {
            return new OkObjectResult(await mediator.Send(transaction));
        }
    }
}