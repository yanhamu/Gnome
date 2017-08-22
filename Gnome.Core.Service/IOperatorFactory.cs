using Gnome.Core.Service.RulesEngine.AST.Syntax;
using Gnome.Core.Service.RulesEngine.Tokenizer;

namespace Gnome.Core.Service.RulesEngine.AST
{
    public interface IOperatorFactory
    {
        ISyntaxNode<bool> Build(IToken value);
    }
}