using MediatR;
using System;

namespace Gnome.Api.Services.Accounts.Requests
{
    public class CreateAccount : IRequest<Account>
    {
        public Guid UserId { get; set; }
        public string Token { get; set; }
        public string Name { get; set; }

        public CreateAccount(Guid userId, string token, string name)
        {
            this.UserId = userId;
            this.Name = name;
            this.Token = token;
        }
    }
}
