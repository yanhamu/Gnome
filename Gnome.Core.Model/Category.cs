using System;

namespace Gnome.Core.Model
{
    public class Category
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public int? ParentId { get; set; }
        public Category Parent { get; set; }
        public string Name { get; set; }
        public bool IsSystem { get; set; }
        public int Type { get; set; }
        public bool IsFallback { get { return Type == TypeEnumeration.Fallback; } }
        public bool IsRoot { get { return ParentId.HasValue == false; } }
        public string Color { get; set; }

        public static class TypeEnumeration
        {
            public const int Envelope = 100;
            public const int Fallback = 200;
        }
    }
}