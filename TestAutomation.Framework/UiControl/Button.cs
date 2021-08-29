using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using TestAutomation.Framework.Browser;
using TestAutomation.Framework.Container;
using TestAutomation.Framework.Core;
using TestAutomation.Framework.Utils;
using TestAutomation.Report;

namespace TestAutomation.Framework.UiControl
{
    public class Button<T> : Control<T> where T : AbstractPage
    {
        public Button(Locator locator, string value, string controlName, params PostAction[] postAction)
            : base(locator, value, controlName, postAction)
        {
            ControlType = "Button";
        }

        public Button(T page, Locator locator, string value, string controlName, params PostAction[] postAction)
            : base(page, locator, value, controlName, postAction)
        {
            ControlType = "Button";
        }

        public T Click()
        {
            try
            {
                Element.Click();
                Logger.AddStep($"[{ControlName}] Button was clicked.");

                ControlPostAction.ManagePostAction(PostConditions, this);
            }
            catch (Exception ex)
            {
                throw new AutomationException("Couldn't click.", this, ex);
            }

            return Page;
        }

        public T ClickJs()
        {
            try
            {
                IJavaScriptExecutor executor = (IJavaScriptExecutor)BrowserManager.Instance.Driver;
                executor.ExecuteScript("arguments[0].click();", Element);
                Logger.AddStep($"[{ControlName}] Button has been clicked.");

                ControlPostAction.ManagePostAction(PostConditions, this);
            }
            catch (Exception ex)
            {
                throw new AutomationException("Couldn't click using JavaScript.", this, ex);
            }

            return Page;
        }

        public T ClickOffset()
        {
            try
            {
                var location = Element.Location;
                var size = Element.Size;

                Actions action = BrowserManager.Instance.Actions;

                action.MoveByOffset(location.X + size.Width / 2, location.Y + size.Height / 2)
                    .Click()
                    .Build()
                    .Perform();

                Logger.AddStep($"[{ControlName}] Button has been clicked.");
                ControlPostAction.ManagePostAction(PostConditions, this);
            }
            catch (Exception ex)
            {
                throw new AutomationException("Couldn't click.", this, ex);
            }

            return Page;
        }
    }
}
