using Gnome.Core.Service.RulesEngine.AST.Syntax;

namespace Gnome.Core.Service.RulesEngine.AST
{
    public interface ISyntaxTreeBuilderFacade
    {
        ISyntaxNode<bool> Build(string expression);
    }
}