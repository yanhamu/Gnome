using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Gnome.Web.ViewComponets
{
    public class NavBar : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(new User());
        }
    }

    public class User
    {
        public bool IsAuthenticated { get; set; }
    }
}
