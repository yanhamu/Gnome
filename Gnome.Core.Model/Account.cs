namespace Gnome.Core.Model
{
    public class Account
    {
        public Account() { }

        public Account(
            int id,
            int userId,
            string name,
            string token)
        {
            this.Id = id;
            this.UserId = userId;
            this.Name = name;
            this.Token = token;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
    }
}