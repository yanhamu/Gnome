using System;

namespace Gnome.Api.Services.Accounts
{
    public class Account
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }

        public Account() { }

        public Account(Guid id, string name, string token)
        {
            this.Id = id;
            this.Name = name;
            this.Token = token;
        }
    }
}