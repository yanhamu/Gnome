namespace Gnome.Core.Service.RulesEngine.Tokenizer
{
    public class StringConstantOperandToken : IToken
    {
        public StringConstantOperandToken(string value)
        {
            this.Value = value;
        }

        public string Value { get; }
    }
}