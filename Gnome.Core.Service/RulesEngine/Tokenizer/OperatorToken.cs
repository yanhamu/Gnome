namespace Gnome.Core.Service.RulesEngine.Tokenizer
{
    public class OperatorToken : IOperator
    {
        public OperatorToken(string value, int precedence, Associativity associativity = Associativity.Left)
        {
            this.Value = value;
            this.Precedence = precedence;
            this.Associativity = associativity;
        }

        public string Value { get; }
        public int Precedence { get; }
        public Associativity Associativity { get; }

        public override string ToString()
        {
            return Value;
        }
    }

    public enum Associativity
    {
        Left,
        Right,
        None
    }
}