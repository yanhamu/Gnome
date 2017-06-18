namespace Gnome.Core.Model
{
    public class FioAccount
    {
        public FioAccount() { }

        public FioAccount(
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