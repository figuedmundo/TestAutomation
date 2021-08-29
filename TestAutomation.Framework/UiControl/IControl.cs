using OpenQA.Selenium;

namespace TestAutomation.Framework.UiControl
{
    public interface IControl
    {
        public string ControlName { get; }
        public IWebElement Element { get; }
    }
}