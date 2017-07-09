using Gnome.Core.DataAccess;
using Gnome.Core.Model;
using Microsoft.AspNetCore.Mvc;

namespace Gnome.Api.Controllers
{
    [Route("api")]
    public class TransactionController : Controller
    {
        private readonly FioTransactionRepository fioRepository;

        public TransactionController(FioTransactionRepository fioRepository)
        {
            this.fioRepository = fioRepository;
        }

        [HttpPost("fio-transactions")]
        public IActionResult CreateFio(FioTransaction transaction)
        {
            fioRepository.Save(transaction);
            return new OkResult();
        }
    }
}
