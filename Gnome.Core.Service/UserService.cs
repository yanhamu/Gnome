using Gnome.Core.DataAccess;
using Gnome.Core.Model;
using Gnome.Core.Service.Interfaces;
using System;

namespace Gnome.Core.Service
{
    public class UserService : IUserService
    {
        private readonly UserRepository repository;
        private readonly UserSecurityRepository securityRepository;
        private readonly IUserSecurityService securityService;

        public UserService(
            UserRepository repository,
            UserSecurityRepository securityRepository,
            IUserSecurityService securityService)
        {
            this.repository = repository;
            this.securityRepository = securityRepository;
            this.securityService = securityService;
        }

        public bool CheckEmailAvailability(string email)
        {
            return repository.CheckEmailAvailability(email);
        }

        public int CreateNew(string email, string password)
        {
            var salt = securityService.GetSalt();
            var pwd = securityService.CreatePassword(password, salt);
            var result = securityRepository.CreateNew(email, pwd, salt);

            if (result == null)
                throw new InvalidOperationException("user was not registered");

            return result.Id;
        }

        public User Verify(string email, string password)
        {
            var user = securityRepository.GetBy(email);
            if (user == null)
                return null;

            if (!securityService.Verify(password, user.Password, user.Salt))
                return null;

            return new User()
            {
                Id = user.Id,
                Email = user.Email
            };
        }
    }
}