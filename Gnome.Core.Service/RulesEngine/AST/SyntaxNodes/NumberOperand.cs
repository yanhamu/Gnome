namespace Gnome.Core.Service.RulesEngine.AST.SyntaxNodes
{
    public class NumberOperand : IOperand<decimal>
    {
        public decimal Value { get; }

        public NumberOperand(decimal value)
        {
            this.Value = value;
        }
    }
}
