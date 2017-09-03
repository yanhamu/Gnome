using System;
using System.Collections.Generic;

namespace Gnome.Core.Service.Categories
{
    public class CategoryTree
    {
        private Dictionary<Guid, CategoryNode> Categories = new Dictionary<Guid, CategoryNode>();
        public CategoryNode Root { get; private set; }
        public CategoryTree(Dictionary<Guid, CategoryNode> categories, CategoryNode root)
        {
            this.Root = root;
            this.Categories = categories;
        }

        public CategoryNode this[Guid id]
        {
            get { return Categories[id]; }
        }

        public IEnumerable<CategoryNode> SubTree(Guid id)
        {
            var node = this[id];
            foreach (var child in node.Children)
            {
                yield return child;

                foreach (var subChild in SubTree(child.Id))
                    yield return child;
            }
        }
    }
}