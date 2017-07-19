using Gnome.Core.Model;

namespace Gnome.Core.Service.Interfaces
{
    public interface IUserService
    {
        bool CheckEmailAvailability(string email);
        int CreateNew(string email, string password);
        User Verify(string email, string password);
    }
}
