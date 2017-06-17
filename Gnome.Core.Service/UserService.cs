using Gnome.Core.DataAccess;
using Gnome.Core.Model;
using Gnome.Core.Service.Interfaces;

namespace Gnome.Core.Service
{
    public class UserService : IUserService
    {
        private readonly UserRepository repository;
        private readonly UserSecurityService securityService;
        private readonly UserSecurityRepository securityRepository;

        public UserService(
            UserRepository repository,
            UserSecurityRepository securityRepository,
            UserSecurityService securityService)
        {
            this.repository = repository;
            this.securityRepository = securityRepository;
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
            var result = securityRepository.CreateNew(email, pwd, salt);

            if (result == null)
                return null;

            return new User()
            {
                Id = result.Id,
                Email = result.Email
            };
        }

        public User Verify(string email, string password)
        {
            var user = securityRepository.GetBy(email);

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