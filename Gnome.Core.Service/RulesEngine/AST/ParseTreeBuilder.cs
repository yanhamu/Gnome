using Gnome.Core.Service.RulesEngine.Tokenizer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gnome.Core.Service.RulesEngine.AST
{
    public class ParseTreeBuilder
    {
        public void Build(List<IToken> tokens)
        {
            var filtered = tokens.Where(t => !(t is SkipToken));

            /* a = 1 and ( b = 2 or c = 3 )
             *           
             *          and
             *          /  \
             *         =   or
             *        /\    /\
             *       a 1   =  =
             *            /|  |\
             *           b 2  c 3
             */

            /* a = 1 and not ( b = 2 or c = 3 )
             *           
             *          and
             *          /  \
             *         =   not
             *        /\     \
             *       a  1     or
             *                / \
             *               =   =
             *              /\   /\
             *             b  2 c  3
             */

            /* a = 1 and ( not  b = 2 ) or c = 3 
            *          
            *              or
            *            /    \
            *          and     =
            *          / \     |\ 
            *         =  not   c 3
            *        /\    \
            *       a  1    =
            *              / \
            *              b  2
            */

            throw new NotImplementedException();
        }
    }
}
