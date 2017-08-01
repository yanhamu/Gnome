using Gnome.Core.Service.RulesEngine.Tokenizer;

namespace Gnome.Core.Service.RulesEngine.AST
{
    public class Node
    {
        public Node Parent { get; set; }
        public Node LeftChild { get; set; }
        public Node RightChild { get; set; }
        public IToken Token { get; set; }

        public Node(Node parent)
        {
            this.Parent = parent;
        }
    }
}
