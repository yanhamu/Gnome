using Gnome.Web.Extensions;
using Gnome.Web.Model;
using Gnome.Web.Model.ViewModel;
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
            var model = new MaskedTransactionList();
            model.Transactions = transactions;
            model.Mask = new TransactionMask()
            {
                Fields = new System.Collections.Generic.List<string>() { "id", "amount", "currency" }
            };
            return View(model);
        }
    }
}