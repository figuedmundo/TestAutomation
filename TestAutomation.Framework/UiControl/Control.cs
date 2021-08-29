using SeleniumExtras.WaitHelpers;
using System;
using TestAutomation.Framework.Browser;
using TestAutomation.Framework.Container;
using TestAutomation.Framework.Core;
using TestAutomation.Framework.Utils;
using TestAutomation.Report;

namespace TestAutomation.Framework.UiControl
{
    public class Control<T> : WebElement, IControl where T : AbstractPage
    {
        public T Page { get; private set; }

        public string ControlType { get; set; } = "Control";

        public Control(Locator locator, string value, string controlName, params PostAction[] postActions)
            : base(locator, value, controlName, postActions)
        {
        }

        public Control(T page, Locator locator, string value, string controlName, params PostAction[] postActions)
            : base(locator, value, controlName, postActions)
        {
            Page = page;
        }

        public virtual string GetText()
        {
            var text = Element.Text;
            return text;
        }

        public virtual T GetText(out string text)
        {
            text = GetText();
            return Page;
        }

        public virtual T SetText(string text)
        {
            try
            {
                Element.SendKeys(text);
                Logger.AddStep($"[{ControlName}] {ControlType} is populated with [{text}]");
                ControlPostAction.ManagePostAction(PostConditions, this);
                return Page;
            }
            catch (Exception ex)
            {
                throw new AutomationException("Not possible to set text", this, ex);
            }
        }

        public bool IsDisplayed()
        {
            var res = Element.Displayed;
            var text = res ? "is" : "is not";
            Logger.AddStep($"[{ControlName}] Control {text} displayed.");

            return res;
        }

        public T IsDisplayed(out bool res)
        {
            res = IsDisplayed();
            return Page;
        }

        public bool IsEnable()
        {
            var res = Element.Enabled;
            var message = res ? "enabled" : "disabled";
            Logger.AddStep($"[{ControlName}] Control is {message}.");

            return res;
        }

        public T AssertElementDisabled()
        {
            if (!IsEnable())
            {
                Logger.AddStep($"[{ControlName}] is Disabled");
            }
            else
            {
                throw new Exception($"[{ControlName}] should be Disabled");
            }

            return Page as T;
        }

        public T AssertElementEnabled()
        {
            if (IsEnable())
            {
                Logger.AddStep($"[{ControlName}] is Enabled");
            }
            else
            {
                throw new Exception($"[{ControlName}] should be Enabled");
            }

            return Page as T;
        }

        public T IsEnable(out bool res)
        {
            res = IsEnable();
            return Page;
        }

        public T DragAndDrop(IControl control)
        {
            var action = BrowserManager.Instance.Actions;
            action
                .MoveToElement(Element)
                .ClickAndHold(Element)
                .MoveToElement(control.Element, control.Element.Size.Width / 2 + 10, control.Element.Size.Height / 2 + 10)
                .Release()
                .Build().Perform();

            Logger.AddStep($"{ControlName} is dragged and dropped to {control.ControlName}.");
            ControlPostAction.ManagePostAction(PostConditions, this);

            return Page;
        }

        public T Highlight()
        {
            try
            {
                Element.Highlight();
            }
            catch (Exception ex)
            {
                throw new AutomationException($"Element {ControlName} cannot be Hihglighted", this, ex);
            }

            return Page;
        }

        public T WaitForElementToBeClickable()
        {
            BrowserManager.Instance.Wait.Until(ExpectedConditions.ElementToBeClickable(Element));
            return Page;
        }

        public string GetAttribute(string attribute)
        {
            return Element.GetAttribute(attribute);
        }

        public T AssertElementDisplayed()
        {
            try
            {
                if (IsDisplayed())
                {
                    Logger.AddStep($"[{ControlName}] {ControlType} is Displayed");
                }
                else
                {
                    throw new AutomationException($"[{ControlName}] {ControlType} is not Displayed", this);
                }
            }
            catch (Exception ex) when (!(ex is AutomationException))
            {
                throw new AutomationException($"Couldn't assert {ControlType} Element.", this, ex);
            }

            return Page;
        }

        public virtual T AssertElementTextContains(string expectedValue)
        {
            string actualValue = GetText();
            if (!string.IsNullOrEmpty(actualValue)
                && actualValue.Contains(expectedValue, StringComparison.OrdinalIgnoreCase))
            { 
                Logger.AddStep($"[{ControlName}] contains text: {expectedValue}");
            }
            else
            {
                throw new Exception($"[{ControlName}] should contains text: {expectedValue}, \nActual value: {actualValue}");
            }

            return Page;
        }

        public override string ToString()
        {
            return $"--> ControlName: [ {ControlName} ] \n--> Type: [ {ControlType} ] \n--> Locator: [ {By} ] \n--> Page: [ {Page} ]";
        }
    }
}
