using Gnome.Core.Service.RulesEngine.Tokenizer;
using System;
using System.Collections.Generic;

namespace Gnome.Core.Service.RulesEngine.AST
{
    public class AbstractSyntacTreeParser
    {
        public Node Build(IEnumerable<IToken> tokens)
        {
            var nodes = new Stack<Node>();
            foreach (var token in tokens)
            {
                //var 
                //switch (token)
                //{
                //    case IOperand operand:
                //        nodes.Push(new Node(operand));
                //        break;
                //    default:
                //        break;
                //}
            }
            throw new NotImplementedException();
        }
    }
}
