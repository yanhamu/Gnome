using Gnome.Core.Service.RulesEngine.AST.SyntaxNodes;
using Gnome.Core.Service.RulesEngine.Tokenizer;
using System.Collections.Generic;

namespace Gnome.Core.Service.RulesEngine.AST
{
    public class OperatorRetrievalResult
    {
        public List<IToken> Tokens { get; set; } = new List<IToken>();
        public IOperator Operator { get; set; }

        public OperatorRetrievalResult(List<IToken> tokens, IOperator @operator)
        {
            this.Tokens = tokens;
            this.Operator = @operator;
        }
    }
}
