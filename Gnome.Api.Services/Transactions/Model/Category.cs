namespace Gnome.Api.Services.Transactions.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }

        public Category(int id, string name, string color)
        {
            this.Id = id;
            this.Name = name;
            this.Color = color;
        }
    }
}
