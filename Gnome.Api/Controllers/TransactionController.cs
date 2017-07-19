using Gnome.Api.Services.Transactions;
using Gnome.Core.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gnome.Api.Controllers
{
    [Route("api")]
    public class TransactionController : Controller
    {
        private readonly IMediator mediator;

        public TransactionController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("fio-transactions")]
        public IActionResult CreateFio([FromBody]FioTransaction transaction)
        {
            var id = mediator.Send(new CreateFioTransaction(transaction));
            return new OkObjectResult(id);
        }
    }
}