using Gnome.Core.Service.RulesEngine.AST.Syntax;
using Gnome.Core.Service.RulesEngine.Tokenizer;

namespace Gnome.Core.Service.RulesEngine.AST
{
    public class SyntaxTreeBuilderFacade : ISyntaxTreeBuilderFacade
    {
        private readonly ShuntingYardParser parser;
        private readonly TreeParser treeParser;
        private readonly SyntaxTreeBuilder syntaxTreeBuilder;

        public SyntaxTreeBuilderFacade()
        {
            this.parser = new ShuntingYardParser(new Lexer());
            this.treeParser = new TreeParser();
            this.syntaxTreeBuilder = new SyntaxTreeBuilder();
        }

        public ISyntaxNode<bool> Build(string expression)
        {
            var tokens = parser.Parse(expression);
            var root = treeParser.Build(tokens);
            return syntaxTreeBuilder.Build(root);
        }
    }
}