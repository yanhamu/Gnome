using Gnome.Api.Filters;
using Gnome.Api.Services;
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

        [HttpPost("transactions/query")]
        public async Task<IActionResult> Search([FromBody] TransactionSearchFilter filter, int page = 1, int pageSize = 20)
        {
            var pagination = new PaginationFilter() { Page = page, PageSize = pageSize };
            return new OkObjectResult(await mediator.Send(new SearchTransaction(filter, pagination, UserId)));
        }

        [IgnoreUserFilter]
        [HttpPost("transactions")]
        public async Task<IActionResult> CreateTransaction([FromBody] CreateTransaction transaction)
        {
            return new OkObjectResult(await mediator.Send(transaction));
        }
    }
}