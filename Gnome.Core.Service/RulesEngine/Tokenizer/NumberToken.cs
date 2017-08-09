namespace Gnome.Core.Service.RulesEngine.Tokenizer
{
    public class NumberToken : IToken
    {
        public string Value { get; }

        public NumberToken(string value)
        {
            this.Value = value;
        }
        public override string ToString()
        {
            return Value;
        }
    }
}
