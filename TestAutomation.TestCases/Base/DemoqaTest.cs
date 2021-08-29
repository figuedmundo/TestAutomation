using NUnit.Framework;
using TestAutomation.Framework.Browser;
using TestAutomation.Pages.Demoqa;

namespace TestAutomation.TestCases.Base
{
    [TestFixture]
    public class DemoqaTest : BaseTest
    {
        public IndexPage IndexPage => new IndexPage();

        [SetUp]
        public void SetupTest()
        {
            BrowserManager.Instance.Visit("https://demoqa.com/");
        }
    }
}
