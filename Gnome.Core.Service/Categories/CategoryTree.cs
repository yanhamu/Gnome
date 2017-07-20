using System.Collections.Generic;

namespace Gnome.Core.Service.Categories
{
    public class CategoryTree
    {
        private Dictionary<int, CategoryNode> Categories = new Dictionary<int, CategoryNode>();
        public CategoryNode Root { get; private set; }
        public CategoryTree(Dictionary<int, CategoryNode> categories, CategoryNode root)
        {
            this.Root = root;
            this.Categories = categories;
        }

        public CategoryNode this[int id]
        {
            get { return Categories[id]; }
        }

        public IEnumerable<CategoryNode> SubTree(int id)
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