namespace Gnome.Core.Service.RulesEngine.Tokenizer
{
    public interface IOperator : IToken
    {
        int Precedence { get; }
        Associativity Associativity { get; }
    }
}