using Gnome.Core.Service.RulesEngine.Tokenizer;
using System;
using System.Collections.Generic;

namespace Gnome.Core.Service.RulesEngine.AST
{
    public class TreeParser
    {
        public TokenNode Build(IEnumerable<IToken> tokens)
        {
            Func<IToken, bool> typeCheck = x => x is IOperand;
            var lastWasOperator = false;

            var nodes = new Stack<TokenNode>();
            foreach (var token in tokens)
            {
                if (token is IOperator && lastWasOperator)
                    typeCheck = x => x is IOperator;

                switch (token)
                {
                    case IOperand operand:
                        nodes.Push(new TokenNode(operand));
                        lastWasOperator = false;
                        typeCheck = x => x is IOperand;
                        break;
                    case IOperator @operator:
                        var o = new TokenNode(@operator);
                        while (nodes.Count != 0 && typeCheck(nodes.Peek().Value))
                            o.AddChild(nodes.Pop());
                        nodes.Push(o);
                        lastWasOperator = true;
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