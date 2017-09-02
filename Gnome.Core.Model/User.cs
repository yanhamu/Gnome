using System;

namespace Gnome.Core.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
    }

    public class UserSecurity
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }
    }
}
