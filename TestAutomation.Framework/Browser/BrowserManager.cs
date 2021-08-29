using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;
using TestAutomation.Configuration;

namespace TestAutomation.Framework.Browser
{
    public class BrowserManager
    {
        public struct Browser
        {
            public const string Firefox = "Firefox";
            public const string Chrome = "Chrome";
        }

        public int DefaultTimeToWait = 30;

        public IWebDriver Driver { get; private set; }
        public WebDriverWait Wait { get; private set; }
        public Actions Actions { get; private set; }

        private static BrowserManager _instance;

        // public static BrowserManager Instance => _instance ??= new BrowserManager();

        public static BrowserManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BrowserManager();
                }

                return _instance;
            }
        }

        public void Init()
        {
            Driver = GetDriver(Settings.Browser);
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(120);
            Driver.Manage().Window.Maximize();
            Driver.Manage().Cookies.DeleteAllCookies();

            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(DefaultTimeToWait));

            Actions = new Actions(Driver);

            //log
        }

        public void Visit(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public void Quit()
        {
            if (Driver != null)
            {
                Driver.Close();
                Driver.Quit();
                Driver.Dispose();

                Driver = null;
                // _instance = null;
                // log
            }
        }


        private IWebDriver GetDriver(string browser)
        {
            IWebDriver driver;
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            switch (browser)
            {
                case Browser.Chrome:

                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("--ignore-certificate-errors");
                    chromeOptions.AddArgument("--allow-running-insecure-content");
                    chromeOptions.AddArgument("--disable-extensions");
                    chromeOptions.AddArgument("--disable-infobars");
                    chromeOptions.AddArgument("--disable-gpu");
                    chromeOptions.AddArgument("--no-sandbox");
                    chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");

                    driver = new ChromeDriver(path, chromeOptions);

                    break;
                case Browser.Firefox:
                    driver = new FirefoxDriver();
                    break;
                default:
                    driver = new ChromeDriver(path);
                    break;
            }
            // log Browser Instantiaded.
            return driver;
        }

        public string ScreenCaptureAsBase64String()
        {
            ITakesScreenshot ts = (ITakesScreenshot)Driver;
            Screenshot screenshot = ts.GetScreenshot();
            return screenshot.AsBase64EncodedString;
        }
    }
}
