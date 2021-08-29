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
    public class Link<T> : Control<T> where T : AbstractPage
    {
        public Link(Locator locator, string value, string controlName, params PostAction[] postAction)
            : base(locator, value, controlName, postAction)
        {
            ControlType = "Link";
        }

        public Link(T page, Locator locator, string value, string controlName, params PostAction[] postAction)
            : base(page, locator, value, controlName, postAction)
        {
            ControlType = "Link";
        }

        public T Click()
        {
            try
            {
                Element.Click();
                Logger.AddStep($"[{ControlName}] {ControlType} was clicked.");

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
