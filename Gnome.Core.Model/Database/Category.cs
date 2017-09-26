using System;

namespace Gnome.Core.Model.Database
{
    public class Category
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid? ParentId { get; set; }
        public Category Parent { get; set; }
        public string Name { get; set; }
        public bool IsSystem { get; set; }
        public bool IsRoot { get { return ParentId.HasValue == false; } }
        public string Color { get; set; }
    }
}