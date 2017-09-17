using Gnome.Core.Model.Database;
using System;

namespace Gnome.Core.Service.Interfaces
{
    public interface IUserService
    {
        bool CheckEmailAvailability(string email);
        void CreateNew(string email, string password, Guid userId);
        User Verify(string email, string password);
    }
}
