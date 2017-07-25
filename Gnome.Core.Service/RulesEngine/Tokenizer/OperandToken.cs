namespace Gnome.Core.Service.RulesEngine.Tokenizer
{
    public class OperandToken : IToken
    {
        public OperandToken(string value)
        {
            this.Value = value;
        }
        public string Value { get; }
    }
}
