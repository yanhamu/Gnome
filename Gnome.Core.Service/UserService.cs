using Gnome.Core.DataAccess;
using Gnome.Core.Model;
using Gnome.Core.Service.Interfaces;

namespace Gnome.Core.Service
{
    public class UserService : IUserService
    {
        private readonly UserRepository repository;
        private readonly UserSecurityService securityService;

        public UserService(
            UserRepository repository,
            UserSecurityService securityService)
        {
            this.repository = repository;
            this.securityService = securityService;
        }

        public bool CheckEmailAvailability(string email)
        {
            return repository.CheckEmailAvailability(email);
        }

        public User CreateNew(string email, string password)
        {
            var salt = securityService.GetSalt();
            var pwd = securityService.CreatePassword(password, salt);
            return repository.CreateNew(email, pwd, salt);
        }

        public User Verify(string email, string password)
        {
            var user = repository.GetBy(email);

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