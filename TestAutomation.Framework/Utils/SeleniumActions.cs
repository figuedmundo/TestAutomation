using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Threading;
using TestAutomation.Framework.Browser;

namespace TestAutomation.Framework.Utils
{
    /// <summary>
    /// All actions to be use for POM
    /// </summary>
    public class SeleniumActions
    {
        protected static IWebDriver Driver => BrowserManager.Instance.Driver;

        /// <summary>
        /// Wait for Web Page to Load Completly
        /// </summary>
        public static void PageLoadComplete()
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
            WebDriverWait wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 20));
            wait.Until(Driver => executor.ExecuteScript("return document.readyState").ToString() == "complete");
        }

        public static void RefreshPage()
        {
            Driver.Navigate().Refresh();
            Sleep(3);
        }

        /// <summary>
        /// Switch to Default Content
        /// </summary>
        /// <param name="value"></param>
        public static void SwitchToDefaultContent()
        {
            Driver.SwitchTo().DefaultContent();
        }

        /// <summary>
        /// iFrame by ID or Name
        /// </summary>
        /// <param name="value"></param>
        public static void SwitchToFrame(string value)
        {
            Driver.SwitchTo().Frame(value);
        }

        /// <summary>
        /// iFrame by IWebElement
        /// </summary>
        /// <param name="locator"></param>
        public static void SwitchToFrame(IWebElement element)
        {
            Driver.SwitchTo().Frame(element);
        }

        /// <summary>
        /// Iframe by index
        /// </summary>
        /// <param name="index"></param>
        public static void SwitchToFrame(int index)
        {
            Driver.SwitchTo().Frame(index);
        }

        /// <summary>
        /// Parent Iframe
        /// </summary>
        public static void SwitchToParentFrame()
        {
            Driver.SwitchTo().ParentFrame();
        }

        /// <summary>  
        /// Switch to Main Window
        /// </summary>
        public static void SwitchToMainWindow()
        {
            Driver.SwitchTo().Window(Driver.WindowHandles.First());
        }
        /// <summary>  
        /// Switch to newly opened window/tab
        /// </summary>
        public static void SwitchToNewWindow()
        {
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
        }

        /// <summary>
        /// Switch to newly opened window that contains popups such as print form
        /// </summary>
        /// <param name="mainWindow"></param>
        public static void SwitchToNewWindow(string mainWindow)
        {
            foreach (string window in Driver.WindowHandles)
            {
                if (mainWindow != window)
                {
                    Driver.SwitchTo().Window(window);
                    break;
                }
            }
        }

        public static void Sleep(int time = 1)
        {
            Thread.Sleep(TimeSpan.FromSeconds(time));
        }
    }
}