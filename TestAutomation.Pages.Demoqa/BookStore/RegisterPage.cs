using System.Threading;
using TestAutomation.Framework.Container;
using TestAutomation.Framework.Core;
using TestAutomation.Framework.UiControl;
using TestAutomation.Framework.Utils;

namespace TestAutomation.Pages.Demoqa.BookStore
{
    public class RegisterPage : AbstractPage
    {
        public TextBox<RegisterPage> FirstnameTextBox => new TextBox<RegisterPage>(this, Locator.Id, "firstname", "Firstname");
        
        public TextBox<RegisterPage> LastnameTextBox => new TextBox<RegisterPage>(this, Locator.Id, "lastname", "Lastname");
        
        public TextBox<RegisterPage> UserNameTextBox => new TextBox<RegisterPage>(this, Locator.Id, "userName", "UserName");
        
        public TextBox<RegisterPage> PasswordTextBox => new TextBox<RegisterPage>(this, Locator.Id, "password", "Password");

        public Button<RegisterPage> RegisterButton => new Button<RegisterPage>(this, Locator.Id, "register", "Register");

        public Button<RegisterPage> BackToLoginButton => new Button<RegisterPage>(this, Locator.Id, "gotologin", "Back to Login");

        public Control<RegisterPage> ErrorMessage => new Control<RegisterPage>(this, Locator.Id, "output", "Error Message");
        
        public RegisterPage CheckCaptcha()
        {
            var captcha = new Button<RegisterPage>(Locator.Id, "g-recaptcha", "Captcha", 
                PostAction.PageLoadComplete, PostAction.Sleep, PostAction.Sleep, PostAction.Sleep);
            captcha.ClickOffset();
            WaitUntilCaptchaIsAccepted();
            return this;
        }

        public RegisterPage WaitUntilCaptchaIsAccepted()
        {
            var frame = new Control<RegisterPage>(Locator.CssSelector, "div#g-recaptcha iframe[title='reCAPTCHA']", "frame");
            SeleniumActions.SwitchToFrame(frame.Element);

            var box = new Button<RegisterPage>(Locator.CssSelector, "span.recaptcha-checkbox", "captcha", 
                PostAction.Sleep);
            box.WaitForElementToBeClickable();
            box.Click();
            var isChecked= box.GetAttribute("aria-checked");

            var cont = 0;
            while (bool.Parse(isChecked) && cont < 60)
            {
                Thread.Sleep(500);
                cont++;
            }

            SeleniumActions.SwitchToMainWindow();
            return this;
        }
    }
}
