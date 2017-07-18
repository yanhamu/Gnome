using Gnome.Core.Model;
using System.Collections.Generic;

namespace Gnome.Core.Service.Categories
{
    public class CategoryNode
    {
        public int Id { get; private set; }
        public CategoryNode Parent { get; private set; }
        public List<CategoryNode> Children { get; private set; }
        public string Name { get; private set; }
        public bool IsSystem { get; private set; }
        public int Type { get; private set; }
        public bool IsFallback { get; private set; }

        public CategoryNode(Category category)
        {
            this.Id = category.Id;
            this.Children = new List<CategoryNode>();
            this.Name = category.Name;
            this.IsSystem = category.IsSystem;
            this.Type = category.Type;
            this.IsFallback = category.IsFallback;
        }

        public void SetParent(CategoryNode category)
        {
            category.Children.Add(this);
            this.Parent = category;
        }
    }
}