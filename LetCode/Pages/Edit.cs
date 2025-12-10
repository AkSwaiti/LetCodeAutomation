using LetCode.Utils;
using OpenQA.Selenium;

namespace LetCode.Pages
{
    class Edit
    {
        private IWebDriver _driver;
        private CustomMethod custom;

        public Edit(IWebDriver driver)
        {
            _driver = driver;
            custom = new CustomMethod(_driver);
        }
        public  IWebElement Name => _driver.FindElement(By.Id("fullName"));

        public IWebElement TextAndTab => _driver.FindElement(By.Id("join"));
        public IWebElement GetData => _driver.FindElement(By.Id("getMe"));
        public IWebElement ClearText => _driver.FindElement(By.Id("clearMe"));
        private IWebElement DisabledField => _driver.FindElement(By.Id("noEdit"));
        public IWebElement ReadOnly => _driver.FindElement(By.Id("dontwrite"));
        public void EnterFullName(string fullName)
        {
            custom.Type(Name, fullName);
        }
        public void AddText(string anyText)
        {
            custom.Type(TextAndTab, anyText);
            custom.PressOn(Keys.Tab);
        }
        public void Gettext()
        {
            custom.GetValue(GetData);
        }

        public void RemoveText()
        {
            custom.ClearField(ClearText);
        }
        public bool CheckFieldIfItsEnabled()
        {
            return DisabledField.Enabled;

        }

        public string GetText()
        {
            string text = custom.GetValue(ReadOnly);
            return text;
        }
        public bool CheckFieldIfItsReadOnly()
        {
            
            string attr = ReadOnly.GetAttribute("readonly");
            return attr != null && (attr == "true" || attr == "false");
        }

    }
}
