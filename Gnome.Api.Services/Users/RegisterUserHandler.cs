using Gnome.Core.Service.Interfaces;
using MediatR;
using System;

namespace Gnome.Api.Services.Users
{
    public class RegisterUserHandler : INotificationHandler<RegisterUser>
    {
        private readonly IUserService userService;

        public RegisterUserHandler(IUserService userService)
        {
            this.userService = userService;
        }

        public void Handle(RegisterUser user)
        {
            if (this.userService.CheckEmailAvailability(user.Email))
            {
                this.userService.CreateNew(user.Email, user.Password);
            }
            throw new InvalidOperationException("email already exists");
        }
    }
}
