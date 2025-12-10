using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;


namespace LetCode.Utils
{
    public class CustomMethod
    {
        private IWebDriver driver;
        private Action action;

        public CustomMethod(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickOn(IWebElement element) => element.Click();

        public void ClearField(IWebElement element) => element.Clear();
        public void Type(IWebElement element, string text)
        {
            element.SendKeys(text);
        }
        public bool IsItEnabled(IWebElement element)
        {
            return element.Enabled;
        }
        public string GetTitle(IWebElement element)
        {
            string title = element.GetAttribute("title");
            return title;
        }
        public string GetValue(IWebElement element)
        {
            string value = element.GetAttribute("value");
            return value;
        }
        public void PressOn( string key)
        {
            Actions action = new Actions(driver);
            action.SendKeys(key).Perform();
        }
    }
}
