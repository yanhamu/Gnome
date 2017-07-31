using System.Collections.Generic;

namespace Gnome.Core.Service.RulesEngine.AST
{
    public class Node<T>
    {
        public T Content { get; set; }
        public List<Node<T>> Children { get; set; } = new List<Node<T>>();
        public Node<T> Parent { get; set; }
    }
}
