using System.Collections.Generic;

namespace Gnome.Core.Service.RulesEngine.AST
{
    public abstract class Node<T>
    {
        public Node(T value)
        {
            this.Value = value;
            this.Children = new LinkedList<Node<T>>();
        }

        public T Value { get; }
        public LinkedList<Node<T>> Children { get; }
        public bool IsLeaf { get { return Children.Count == 0; } }
    }
}