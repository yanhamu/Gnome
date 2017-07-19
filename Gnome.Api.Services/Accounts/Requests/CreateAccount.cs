using MediatR;

namespace Gnome.Api.Services.Accounts.Requests
{
    public class CreateAccount : IRequest<Account>
    {
        public int UserId { get; set; }
        public string Token { get; set; }
        public string Name { get; set; }

        public CreateAccount(int userId, string token, string name)
        {
            this.UserId = userId;
            this.Name = name;
            this.Token = token;
        }
    }
}
