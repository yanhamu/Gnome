using Gnome.Core.Service.RulesEngine.Tokenizer;
using System.Collections.Generic;

namespace Gnome.Core.Service.RulesEngine.AST
{
    public class Node
    {
        private List<Node> children = new List<Node>();

        public Node Parent { get; set; }
        public IToken Token { get; set; }

        public bool IsBinary { get { return children.Count == 2; } }
        public void AddChild(Node node)
        {
            children.Add(node);
        }

        public Node Left
        {
            get
            {
                return children.Count > 1
                    ? children[0]
                    : null;
            }
            set
            {
                children[0] = value;
            }
        }
        public Node Right
        {
            get
            {
                return children.Count > 1
                    ? children[1]
                    : null;
            }
            set
            {
                children[1] = value;
            }
        }


        public Node(Node parent)
        {
            this.Parent = parent;
        }
    }
}
