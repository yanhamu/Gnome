using Gnome.Api.Filters;
using Gnome.Api.Model;
using Gnome.Api.Services;
using Gnome.Api.Services.Transactions.Requests;
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

        [HttpPost("transactions/query")]
        public async Task<IActionResult> Search([FromBody] Filter filter, int page = 1, int pageSize = 20)
        {
            var pagination = new PaginationFilter() { Page = page, PageSize = pageSize };
            return new OkObjectResult(await mediator.Send(new SearchTransaction(filter.Create(), pagination, UserId)));
        }

        [IgnoreUserFilter]
        [HttpPost("transactions")]
        public async Task<IActionResult> CreateTransaction([FromBody] CreateTransaction transaction)
        {
            return new OkObjectResult(await mediator.Send(transaction));
        }
    }

    public class Filter
    {
        public ClosedInterval DateFilter { get; set; }
        public List<Guid> Accounts { get; set; } = new List<Guid>();
        public List<Guid> IncludeExpressions { get; set; } = new List<Guid>();
        public List<Guid> ExcludeExpressions { get; set; } = new List<Guid>();

        public Gnome.Core.Service.Search.Filters.TransactionSearchFilter Create()
        {
            return new Core.Service.Search.Filters.TransactionSearchFilter(this.DateFilter.Create(), Accounts, IncludeExpressions, ExcludeExpressions);
        }
    }
}