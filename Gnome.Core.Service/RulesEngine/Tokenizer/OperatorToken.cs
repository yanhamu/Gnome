namespace Gnome.Core.Service.RulesEngine.Tokenizer
{
    public class OperatorToken : IToken
    {
        public OperatorToken(string value)
        {
            this.Value = value;
        }

        public string Value { get; }

        public override string ToString()
        {
            return Value;
        }
    }
}