using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TestAutomation.Framework.Browser;

namespace TestAutomation.Framework.Core
{
    public class Finder
    {
        public static IWebElement FindElement(WebElement element)
        {
            return BrowserManager.Instance.Wait.Until(d => d.FindElement(element.By));
        }

        public static IReadOnlyCollection<IWebElement> FindElements(WebElement element)
        {
            return BrowserManager.Instance.Wait.Until(d => d.FindElements(element.By));
        }

        public static IWebElement TryFind(WebElement element)
        {
            try
            {
                return BrowserManager.Instance.Driver.FindElement(element.By);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

}
