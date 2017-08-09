namespace Gnome.Core.Service.RulesEngine.Tokenizer
{
    public class NumberToken : IOperand
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
