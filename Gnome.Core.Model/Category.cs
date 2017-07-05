namespace Gnome.Core.Model
{
    public class Category
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ParentId { get; set; }
        public Category Parent { get; set; }
        public string Name { get; set; }
        public bool IsSystem { get; set; }
        public int Type { get; set; }
    }
}
