using Gnome.Core.Service.RulesEngine.Tokenizer;
using System.Collections.Generic;

namespace Gnome.Core.Service.RulesEngine.AST
{
    public class Node
    {
        public IToken Token { get; }

        public LinkedList<Node> Children { get; set; } = new LinkedList<Node>();

        public Node(IToken token)
        {
            this.Token = token;
        }

        public void AddChild(Node node)
        {
            Children.AddFirst(node);
        }
    }
}
