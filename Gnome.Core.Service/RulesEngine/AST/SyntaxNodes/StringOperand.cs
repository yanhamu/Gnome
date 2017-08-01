namespace Gnome.Core.Service.RulesEngine.AST.SyntaxNodes
{
    public class StringOperand : IOperand<string>
    {
        public string Value { get; }

        public StringOperand(string value)
        {
            this.Value = value;
        }
    }
}