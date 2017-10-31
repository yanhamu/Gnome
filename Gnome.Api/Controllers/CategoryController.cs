using Gnome.Api.Services.Categories.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Gnome.Api.Controllers
{
    [Route("api/categories")]
    public class CategoryController : IUserAuthenticatedController
    {
        private readonly IMediator mediator;

        public Guid UserId { get; set; }

        public CategoryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet()]
        public async Task<IActionResult> List()
        {
            return new OkObjectResult(await mediator.Send(new ListCategories(UserId)));
        }

        [HttpGet("{categoryId:Guid}")]
        public async Task<IActionResult> Get(Guid categoryId)
        {
            return new OkObjectResult(await mediator.Send(new GetCategory(categoryId, UserId)));
        }

        [HttpPut("{categoryId:Guid}")]
        public async Task<IActionResult> Update(Guid categoryId, [FromBody]Category category)
        {
            return new OkObjectResult(await mediator.Send(new UpdateCategory(categoryId, category.ParentId, category.Name, category.Color)));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateCategory category)
        {
            category.UserId = UserId;
            return new OkObjectResult(await mediator.Send(category));
        }

        [HttpDelete]
        public async Task<IActionResult> Remove([FromBody]RemoveCategory command)
        {
            command.UserId = UserId;

            await mediator.Publish(command);
            return new NoContentResult();
        }
    }

    public class Category
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid? ParentId { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
    }
}