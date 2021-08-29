using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TestAutomation.Framework.Browser;
using TestAutomation.Framework.Core;

namespace TestAutomation.Framework.Utils
{
    public static class ExtensionMethods
    {

        public static IWebElement FindElementFromHere(this IWebElement element, Locator locator, string value,
            int timeout = 10, int pollingInterval = 200)
        {
            return FindElementFromHere(element, WebElement.SearchBy(locator, value), timeout, pollingInterval);
        }

        public static IWebElement FindElementFromHere(this IWebElement element, By locator,
            int timeout = 10, int pollingInterval = 200)
        {
            try
            {
                var wait = new DefaultWait<IWebElement>(element)
                {
                    Timeout = TimeSpan.FromSeconds(timeout),
                    PollingInterval = TimeSpan.FromMilliseconds(pollingInterval)
                };
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException),
                    typeof(NotFoundException),
                    typeof(StaleElementReferenceException));

                var webElement = wait.Until(ele => ele.FindElement(locator));

                if (webElement.Displayed)
                {
                    return webElement;
                }
                throw new ElementNotVisibleException($"Element: {locator} is not visible.");
            }
            catch (Exception ex)
            {
                throw new AutomationException("Element not Found: " + locator, ex);
            }
        }

        public static IReadOnlyCollection<IWebElement> FindElementsFromHere(this IWebElement element,
            Locator locator, string value, int timeout = 10, int pollingInterval = 200)
        {
            return FindElementsFromHere(element, WebElement.SearchBy(locator, value), timeout, pollingInterval);
        }

        public static IReadOnlyCollection<IWebElement> FindElementsFromHere(this IWebElement element, By locator,
            int timeout = 10, int pollingInterval = 200)
        {
            try
            {
                var wait = new DefaultWait<IWebElement>(element)
                {
                    Timeout = TimeSpan.FromSeconds(timeout),
                    PollingInterval = TimeSpan.FromMilliseconds(pollingInterval)
                };
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException),
                    typeof(NotFoundException),
                    typeof(StaleElementReferenceException));

                var webElements = wait.Until(ele => ele.FindElements(locator));

                if (webElements.Any())
                {
                    return webElements;
                }

                throw new ElementNotVisibleException($"Elements: {locator} not found.");
            }
            catch (Exception ex)
            {
                throw new NoSuchElementException(ex.Message + " - " + locator);
            }
        }

        public static void Highlight(this IWebElement element)
        {
            var jsDriver = (IJavaScriptExecutor)BrowserManager.Instance.Driver;
            const string highlightJavascript =
                @"arguments[0].style.cssText = ""border-width: 3px; border-style: solid; border-color: blue"";";

            var originalElementBorder = (string)jsDriver.ExecuteScript(highlightJavascript, element);
            Thread.Sleep(3000);
        }

        public static void ScrollToView(this IWebElement element)
        {
            var size = BrowserManager.Instance.Driver.Manage().Window.Size;
            var positionY = element.Location.Y;
            var elementHeight = element.Size.Height;

            if (positionY + elementHeight > size.Height - 120)
            {
                ScrollTo(0, positionY + elementHeight);
                SeleniumActions.Sleep();
            }
        }

        private static void ScrollTo(int xPosition = 0, int yPosition = 0)
        {
            var jsDriver = (IJavaScriptExecutor)BrowserManager.Instance.Driver;
            var js = $"window.scrollTo({xPosition}, {yPosition})";
            jsDriver.ExecuteScript(js);
        }
    }
}
