using System.Threading.Tasks;

namespace Gnome.Web.Services.Interfaces
{
    public interface IUserService
    {
        Task<Model.User> Get();
    }
}
