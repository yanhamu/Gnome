namespace Gnome.Core.Service.RulesEngine.AST.SyntaxNodes
{
    public class EqualsNumeric : IOperator
    {
        public IOperand<decimal> Left { get; }
        public IOperand<decimal> Right { get; }

        public EqualsNumeric(IOperand<decimal> left, IOperand<decimal> right)
        {
            this.Left = left;
            this.Right = right;
        }

        public bool Evaluate()
        {
            return Left.Value == Right.Value;
        }
    }
}
