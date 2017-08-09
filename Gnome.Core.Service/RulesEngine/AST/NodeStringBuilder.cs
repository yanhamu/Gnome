using Gnome.Core.Service.RulesEngine.Tokenizer;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Core.Service.RulesEngine.AST
{
    public class TokenStringBuilder
    {
        public string Build(Node root)
        {
            return string.Join(" ", GetTokens(root).Select(t => t.ToString()));
        }

        private List<IToken> GetTokens(Node root)
        {
            var list = new List<IToken>();
            list.Add(new OpenParenthesisToken());
            if (root.Left != null)
                list.AddRange(GetTokens(root.Left));
            list.Add(root.Token);
            if (root.Right != null)
                list.AddRange(GetTokens(root.Right));
            list.Add(new ClosingParenthesisToken());
            return list;
        }
    }
}