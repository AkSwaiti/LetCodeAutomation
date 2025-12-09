using OpenQA.Selenium;

namespace LetCode.Utils
{
    public class CustomMethod
    {
        private IWebDriver driver;

        public CustomMethod(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickOn(IWebElement element) => element.Click();

        public void Type(IWebElement element, string text) => element.SendKeys(text);

        public string GetTitle(IWebElement element) 
        {
            string title = element.GetAttribute("title");
            return title;
        }

    }
}
