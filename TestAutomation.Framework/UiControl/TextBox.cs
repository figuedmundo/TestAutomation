using OpenQA.Selenium;
using System;
using System.Runtime.InteropServices;
using TestAutomation.Framework.Container;
using TestAutomation.Framework.Core;
using TestAutomation.Framework.Utils;
using TestAutomation.Report;

namespace TestAutomation.Framework.UiControl
{
    public class TextBox<T> : Control<T> where T : AbstractPage
    {
        public TextBox(Locator locator, string value, string controlName, params PostAction[] postAction)
            : base(locator, value, controlName, postAction)
        {
            ControlType = "Text Box";
        }

        public TextBox(T page, Locator locator, string value, string controlName, params PostAction[] postAction)
            : base(page, locator, value, controlName, postAction)
        {
            ControlType = "Text Box";
        }

        public T Clear()
        {
            try
            {
                SelectAllText(Element);
                Element.SendKeys(Keys.Delete);
                return Page;
            }
            catch (Exception ex)
            {
                throw new AutomationException("Not possible to clear text", this, ex);
            }
        }

        private void SelectAllText(IWebElement element)
        {
            element.Clear();
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                || RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                element.SendKeys(Keys.Control + "A");
            }
            else
            {
                element.SendKeys(Keys.Command + "A");
            }
        }

        public override T SetText(string text)
        {
            try
            {
                SelectAllText(Element);
                Element.SendKeys(text);
                Logger.AddStep($"[{ControlName}] TextBox is populated with [{text}]");
                ControlPostAction.ManagePostAction(PostConditions, this);
                return Page;
            }
            catch (Exception ex)
            {
                throw new AutomationException("Not possible to set text", this, ex);
            }
        }

        public override string GetText()
        {
            return Element.GetAttribute("value");
        }
    }
}
