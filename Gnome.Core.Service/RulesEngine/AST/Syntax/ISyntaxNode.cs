using Gnome.Core.Service.Transactions;

namespace Gnome.Core.Service.RulesEngine.AST.Syntax
{
    public interface ISyntaxNode<T>
    {
        T Evaluate(TransactionRow row);
    }
}
