using Gnome.Api.Services.Categories.Requests;
using Gnome.Core.Model;
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

        [HttpGet("{categoryId:int}")]
        public async Task<IActionResult> Get(int categoryId)
        {
            return new OkObjectResult(await mediator.Send(new GetCategory(categoryId, UserId)));
        }

        [HttpPut("{categoryId:int}")]
        public async Task<IActionResult> Update(int categoryId, [FromBody]Category category)
        {
            return new OkObjectResult(await mediator.Send(new UpdateCategory(categoryId, category.ParentId, category.Name)));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateCategory category)
        {
            category.UserId = UserId;
            return new OkObjectResult(await mediator.Send(category));
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(RemoveCategory command)
        {
            await mediator.Publish(command);
            return new NoContentResult();
        }
    }
}