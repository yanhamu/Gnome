using Xunit;

namespace Gnome.Core.Service.Tests.RulesEngine
{
    public class RuleTests
    {
        [Fact]
        public void Should_Match()
        {
            /*
             * 
             * examples
             * 
             * "variablesymbol = '111' and counterpartaccount = '555'"
             * "messageforreceipient contains 'vyber z bankomatu'"
             * '120' = '120' contains '20'
             * comment contains 'ahoj' or counterpartaccount = '333'
             * 
             */

            Assert.True(false);
        }
    }
}