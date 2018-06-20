using Gnome.Core.Service.Initialization;
using Gnome.Core.Service.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Gnome.Api.Services.Users
{
    public class RegisterUserHandler : INotificationHandler<RegisterUser>
    {
        private readonly IUserService userService;
        private readonly IEnumerable<IInitializationService> initServices;

        public RegisterUserHandler(
            IUserService userService,
            IEnumerable<IInitializationService> initServices)
        {
            this.userService = userService;
            this.initServices = initServices;
        }

        public async Task Handle(RegisterUser user, CancellationToken cancellationToken)
        {
            if (await this.userService.CheckEmailAvailability(user.Email) == false)
                throw new InvalidOperationException("email already exists");

            var userId = Guid.NewGuid();
            this.userService.CreateNew(user.Email, user.Password, userId);

            initServices
                .ToList()
                .OrderBy(s => s.Order)
                .ToList()
                .ForEach(s => s.Initialize(userId));
        }
    }
}
