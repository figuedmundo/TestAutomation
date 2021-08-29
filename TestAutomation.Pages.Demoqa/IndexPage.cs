using TestAutomation.Framework.Container;
using TestAutomation.Framework.Core;
using TestAutomation.Framework.UiControl;

namespace TestAutomation.Pages.Demoqa
{
    public class IndexPage : AbstractPage
    {
        public Button<IndexPage> BookStoreApplicationButton =>
            new Button<IndexPage>(this, Locator.XPath, "//div[contains(@class,'top-card')][.//h5[text()='Book Store Application']]", "Book Store Application");

        public Button<IndexPage> InteractionsButton =>
            new Button<IndexPage>(this, Locator.XPath, "//div[contains(@class,'top-card')][.//h5[text()='Interactions']]", "Interactions");

        public FromIndexPageTo GoTo => new FromIndexPageTo();
    }

    public class FromIndexPageTo
    {
        
        public LeftNavigationBar LeftNavigationBar => new LeftNavigationBar();

    }
}
