using OpenQA.Selenium;
using System.Collections.Generic;
using TestAutomation.Framework.Utils;

namespace TestAutomation.Framework.Core
{
    public class WebElement
    {
        public By By { get; private set; }
        public string ControlName { get; private set; }
        public PostAction[] PostConditions { get; set; }

        public WebElement(Locator locator, string value, string controlName)
        {
            ControlName = controlName;
            By = SearchBy(locator, value);
            PostConditions = new[] { PostAction.None };
        }

        public WebElement(Locator locator, string value, string controlName, PostAction[] postActions)
        {
            ControlName = controlName;
            By = SearchBy(locator, value);
            PostConditions = postActions ?? (new[] { PostAction.None });
        }

        public virtual IWebElement Element
        {
            get
            {
                var _element = Finder.FindElement(this);
                _element.ScrollToView();

                return _element;
            }
        }

        public IReadOnlyCollection<IWebElement> Elements
        {
            get
            {
                return Finder.FindElements(this);
            }
        }

        public static By SearchBy(Locator locator, string value)
        {
            By by;
            switch (locator)
            {
                case Locator.Id:
                    by = By.Id(value);
                    break;
                case Locator.ClassName:
                    by = By.ClassName(value);
                    break;
                case Locator.CssSelector:
                    by = By.CssSelector(value);
                    break;
                case Locator.LinkText:
                    by = By.LinkText(value);
                    break;
                case Locator.Name:
                    by = By.Name(value);
                    break;
                case Locator.PartialLinkText:
                    by = By.PartialLinkText(value);
                    break;
                case Locator.TagName:
                    by = By.TagName(value);
                    break;
                case Locator.XPath:
                    by = By.XPath(value);
                    break;
                default:
                    by = null;
                    break;
            }

            return by;
        }
    }
}
