namespace Gnome.Core.Service.RulesEngine.AST.SyntaxNodes
{
    public interface IOperand<T>
    {
        T Value { get; }
    }
}