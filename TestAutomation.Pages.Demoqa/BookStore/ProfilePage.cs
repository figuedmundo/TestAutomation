using TestAutomation.Framework.Container;
using TestAutomation.Framework.Core;
using TestAutomation.Framework.UiControl;

namespace TestAutomation.Pages.Demoqa.BookStore
{
    public class ProfilePage : AbstractPage
    {
        public Control<ProfilePage> UserNameField => new Control<ProfilePage>(this, Locator.Id, "userName-value", "User Name");

    }
}
