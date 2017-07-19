using MediatR;

namespace Gnome.Api.Services.Users
{
    public class RegisterUser : INotification
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}