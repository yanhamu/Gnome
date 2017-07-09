using Gnome.Web.Extensions;
using Gnome.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gnome.Web.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly CategoryService categoryService;

        public CategoryController(CategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(categoryService.GetModel(this.UserId));
        }
    }
}
