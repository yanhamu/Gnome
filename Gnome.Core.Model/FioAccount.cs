using System;

namespace Gnome.Core.Model
{
    public class FioAccount
    {
        public FioAccount() { }

        public FioAccount(
            Guid id,
            Guid userId,
            string name,
            string token)
        {
            this.Id = id;
            this.UserId = userId;
            this.Name = name;
            this.Token = token;
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
    }
}