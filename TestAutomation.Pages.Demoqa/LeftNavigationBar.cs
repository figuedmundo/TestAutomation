using TestAutomation.Framework.Container;
using TestAutomation.Framework.Core;
using TestAutomation.Framework.UiControl;
using TestAutomation.Pages.Demoqa.BookStore;
using TestAutomation.Pages.Demoqa.Interactions;

namespace TestAutomation.Pages.Demoqa
{
    public class LeftNavigationBar : AbstractPage
    {
        public Button<LeftNavigationBar> Menu(string value)
        {
            return new Button<LeftNavigationBar>(this, Locator.XPath, $"//li[contains(@class,'btn-light')][.//span[text()='{value}']]", value,
                PostAction.PageLoadComplete, PostAction.Sleep);
        }

        public FromLeftNavigationBarTo GoTo => new FromLeftNavigationBarTo();
    }

    public class FromLeftNavigationBarTo
    {
        public SortablePage SortablePage => new SortablePage();
        public LoginPage LoginPage => new LoginPage();
    }

    public struct MenuOption
    {
        public const string Sortable = "Sortable";
        public const string Login = "Login";
        public const string BookStore = "Book Store";
        public const string Profile = "Profile";
    }
}
