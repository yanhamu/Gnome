using Gnome.Api.Services.Categories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Gnome.Api.Controllers
{
    [Route("api/categories")]
    public class CategoryController : BaseController
    {
        private readonly IMediator mediator;

        public CategoryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet()]
        public async Task<IActionResult> List()
        {
            return new OkObjectResult(await mediator.Send(new ListCategories(UserId)));
        }
    }
}