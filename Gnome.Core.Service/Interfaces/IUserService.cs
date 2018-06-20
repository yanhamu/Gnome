using Gnome.Core.Model.Database;
using System;
using System.Threading.Tasks;

namespace Gnome.Core.Service.Interfaces
{
    public interface IUserService
    {
        Task<bool> CheckEmailAvailability(string email);
        void CreateNew(string email, string password, Guid userId);
        User Verify(string email, string password);
    }
}
