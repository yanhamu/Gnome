using Gnome.Core.Service.Categories;
using Gnome.Core.Service.Interfaces;
using MediatR;
using System;

namespace Gnome.Api.Services.Users
{
    public class RegisterUserHandler : INotificationHandler<RegisterUser>
    {
        private readonly IUserService userService;
        private readonly ICategoryInitializeService categoryInitService;

        public RegisterUserHandler(
            IUserService userService,
            ICategoryInitializeService categoryInitService)
        {
            this.userService = userService;
            this.categoryInitService = categoryInitService;
        }

        public void Handle(RegisterUser user)
        {
            if (this.userService.CheckEmailAvailability(user.Email) == false)
                throw new InvalidOperationException("email already exists");

            var userId = Guid.NewGuid();
            this.userService.CreateNew(user.Email, user.Password, userId);
            categoryInitService.Initialize(userId);
        }
    }
}
