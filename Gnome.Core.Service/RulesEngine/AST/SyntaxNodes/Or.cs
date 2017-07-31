namespace Gnome.Core.Service.RulesEngine.AST.SyntaxNodes
{
    public class Or : IOperator
    {
        public IOperator Left { get; }
        public IOperator Right { get; }

        public Or(IOperator left, IOperator right)
        {
            this.Left = left;
            this.Right = right;
        }

        public bool Evaluate()
        {
            return Left.Evaluate() || Right.Evaluate();
        }
    }
}
