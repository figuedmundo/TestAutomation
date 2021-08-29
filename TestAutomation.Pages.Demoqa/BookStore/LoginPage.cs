using TestAutomation.Framework.Container;
using TestAutomation.Framework.Core;
using TestAutomation.Framework.UiControl;

namespace TestAutomation.Pages.Demoqa.BookStore
{
    public class LoginPage : AbstractPage
    {
        public TextBox<LoginPage> UserNameTextBox => new TextBox<LoginPage>(this, Locator.Id, "userName", "UserName");

        public TextBox<LoginPage> PasswordTextBox => new TextBox<LoginPage>(this, Locator.Id, "password", "Password");

        public Button<LoginPage> LoginButton => new Button<LoginPage>(this, Locator.Id, "login", "Login");

        public Button<LoginPage> NewUserButton => new Button<LoginPage>(this, Locator.Id, "newUser", "New User", 
            PostAction.PageLoadComplete, PostAction.Sleep);

        public Control<LoginPage> ErrorMessage => new Control<LoginPage>(this, Locator.CssSelector, "div#output p", "Error Message");

        public FromLoginPageTo GoTo => new FromLoginPageTo();
    }

    public class FromLoginPageTo
    {
        public RegisterPage RegisterPage => new RegisterPage();

        public ProfilePage ProfilePage => new ProfilePage();
    }
}
