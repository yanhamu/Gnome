using Gnome.Core.Service.Interfaces;
using System;

namespace Gnome.Api.Services.Users
{
    public class UsersService
    {
        private readonly IUserService userService;

        public UsersService(IUserService userService)
        {
            this.userService = userService;
        }

        public void CreateNewUser(User user)
        {
            if (this.userService.CheckEmailAvailability(user.Email))
            {
                this.userService.CreateNew(user.Email, user.Password);
            }
            throw new InvalidOperationException("email already exists");
        }
    }
}
