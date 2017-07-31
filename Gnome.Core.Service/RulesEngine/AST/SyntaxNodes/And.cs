namespace Gnome.Core.Service.RulesEngine.AST.SyntaxNodes
{
    public class And : IOperator
    {
        public IOperator Left { get; }
        public IOperator Right { get; }

        public And(IOperator left, IOperator right)
        {
            this.Left = left;
            this.Right = right;
        }

        public bool Evaluate()
        {
            return Left.Evaluate() && Right.Evaluate();
        }
    }
}
