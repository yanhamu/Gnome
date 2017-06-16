using Gnome.Web.Extensions;
using Gnome.Web.Model;
using Gnome.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Gnome.Web.Controllers
{
    public class TransactionController : BaseController
    {
        private readonly ITransactionService transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            this.transactionService = transactionService;
        }

        [HttpGet]
        public IActionResult List(TransactionFilter filter)
        {
            var transactions = transactionService.GetTransactions(UserId, filter);
            return View(transactions);
        }
    }
}