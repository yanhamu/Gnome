using Gnome.Api.Services.CategoryTransactions.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Gnome.Api.Controllers
{
    [Route("api")]
    public class CategoryTransactionController : BaseController
    {
        private readonly IMediator mediator;

        public CategoryTransactionController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("categories/{categoryId}/transaction{transactionId}")]
        public async Task<IActionResult> AssignCategoryTransaction(int categoryId, int transactionId)
        {
            await mediator.Send(new CreateCategoryTransaction(categoryId, transactionId));
            return new NoContentResult();
        }

        [HttpDelete("categories/{categoryId}/transaction{transactionId}")]
        public async Task<IActionResult> RemoveCategoryTransaction(int categoryId, int transactionId)
        {
            await mediator.Send(new RemoveCategoryTransaction(categoryId, transactionId));
            return new NoContentResult();
        }
    }
}
