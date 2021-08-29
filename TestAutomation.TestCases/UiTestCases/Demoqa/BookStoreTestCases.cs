using NUnit.Framework;
using TestAutomation.Framework.Utils;
using TestAutomation.Pages.Demoqa;
using TestAutomation.TestCases.Base;
using TestAutomation.TestCases.UiTestCases.Demoqa;
using TestAutomation.TestCases.Utils;

namespace TestAutomation.TestCases.UiTestCasess.Demoqa
{
    public class BookStoreTestCases : DemoqaTest
    {
        [Test]
        [Ignore("exit")]
        public void CreateUserNoPassword()
        {
            var first = StringUtils.RandomAlphaNumeric();
            var last = StringUtils.RandomAlphaNumeric();
            var user = StringUtils.RandomAlphaNumeric();
            var message = "Passwords must have at least one non alphanumeric character, one digit ('0'-'9'), one uppercase " +
                $"('A'-'Z'), one lowercase ('a'-'z'), one special character and Password must be eight characters or longer.";

            IndexPage
                .BookStoreApplicationButton.Click()

                .GoTo.LeftNavigationBar
                .Menu(MenuOption.Login).Click()

                .GoTo.LoginPage
                .NewUserButton.Click()

                .GoTo.RegisterPage
                .UserNameTextBox.SetText(first)
                .LastnameTextBox.SetText(last)
                .UserNameTextBox.SetText(user)
                .CheckCaptcha()
                .RegisterButton.Click()
                .ErrorMessage.AssertElementTextContains(message);
        }

        [Test]
        public void TestLoginInvalidUser()
        {
            var user = new UserData();
            user.New();

            IndexPage
                .BookStoreApplicationButton.Click()

                .GoTo.LeftNavigationBar
                .Menu(MenuOption.Login).Click()

                .GoTo.LoginPage
                .UserNameTextBox.SetText(user.UserName)
                .PasswordTextBox.SetText(user.Password)
                .LoginButton.Click()

                .ErrorMessage.AssertElementTextContains("Invalid username or password!");
                ;
        }

        [Test]
        [Ignore("exit")]
        public void TestLoginUser()
        {
            var user = new UserData();
            user.New();

            Precondition.CreateUser(user);

            IndexPage
                .BookStoreApplicationButton.Click()

                .GoTo.LeftNavigationBar
                .Menu(MenuOption.Login).Click()

                .GoTo.LoginPage
                .UserNameTextBox.SetText(user.UserName)
                .PasswordTextBox.SetText(user.Password)
                .LoginButton.Click()

                .GoTo.ProfilePage
                .UserNameField.AssertElementTextContains(user.UserName);
            ;
        }
    }
}
