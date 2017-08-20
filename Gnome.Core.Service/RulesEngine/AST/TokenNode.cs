using Gnome.Core.Service.RulesEngine.Tokenizer;

namespace Gnome.Core.Service.RulesEngine.AST
{
    public class TokenNode : Node<IToken>
    {
        public TokenNode(IToken token) : base(token) { }

        public void AddChild(TokenNode node)
        {
            Children.AddFirst(node);
        }
    }
}