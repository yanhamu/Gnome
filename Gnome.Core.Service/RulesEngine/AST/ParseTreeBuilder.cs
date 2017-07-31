using Gnome.Core.Service.RulesEngine.Tokenizer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Core.Service.RulesEngine.AST
{
    public class ParseTreeBuilder
    {
        public Node<IToken> Build(List<IToken> tokens)
        {
            var filtered = tokens.Where(t => !(t is SkipToken));
            throw new NotImplementedException();
        }
    }
}
