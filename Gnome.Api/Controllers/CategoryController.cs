using Gnome.Api.Services.Categories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult List()
        {
            return new OkObjectResult(mediator.Send(new ListCategories(UserId)));
        }
    }
}

// todo rewrite controllers to async