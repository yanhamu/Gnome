namespace Gnome.Core.Service.RulesEngine.AST.SyntaxNodes
{
    public class Not : IOperator
    {
        public IOperator Operator { get; }

        public Not(IOperator @operator)
        {
            this.@Operator = @operator;
        }

        public bool Evaluate()
        {
            return !Operator.Evaluate();
        }
    }
}
