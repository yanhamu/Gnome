using Gnome.Core.Service.RulesEngine.Tokenizer;
using System;
using System.Collections.Generic;

namespace Gnome.Core.Service.RulesEngine.AST
{
    public class AbstractSyntaxTreeParser
    {
        public TokenNode Build(IEnumerable<IToken> tokens)
        {
            var nodes = new Stack<TokenNode>();
            foreach (var token in tokens)
            {
                switch (token)
                {
                    case IOperand operand:
                        nodes.Push(new TokenNode(operand));
                        break;
                    case IOperator @operator:
                        var o = new TokenNode(@operator);
                        while (nodes.Count != 0)
                            o.AddChild(nodes.Pop());
                        nodes.Push(o);
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }

            if (nodes.Count != 1)
                throw new InvalidOperationException();

            return nodes.Pop();
        }
    }
}