namespace Gnome.Core.Service.RulesEngine.Tokenizer
{
    public class OperatorToken : IOperator
    {
        public OperatorToken(string value, int precedence)
        {
            this.Value = value;
            this.Precedence = precedence;
        }

        public string Value { get; }
        public int Precedence { get; }

        public override string ToString()
        {
            return Value;
        }
    }
}