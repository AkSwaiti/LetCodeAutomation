using LetCode.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetCode.Pages
{
     class Edit
    {
        private IWebDriver driver;
        private CustomMethod custom;
        public Edit(IWebDriver driver)
        {
            this.driver = driver;
            this.custom = new CustomMethod(driver);
        }
        private IWebElement Name => driver.FindElement(By.Id("fullName"));
        private IWebElement TextAndTab => driver.FindElement(By.Id("join"));
        private IWebElement ClearText => driver.FindElement(By.Id("clearMe"));
        private IWebElement DisabledField => driver.FindElement(By.Id("noEdit"));
        private IWebElement ReadOnly => driver.FindElement(By.Id("dontwrite"));
        public void EnterFullName(string fullName)
        {
            custom.Type(Name, fullName);
        }
        public void AddText(string anyText)
        {
            custom.Type(TextAndTab, anyText);
            custom.PressOn("Tab");

        }
        public void RemoveText(IWebElement element)
        {
            element = ClearText;
            element.Clear();
        }
        public  void CheckFieldIfItsEnabled(IWebElement element)
        {
            element = DisabledField;
            custom.IsItEnabled(element);
        }
        public void CheckFieldIfItsReadOnly(IWebElement element, string value)
        {
            if (element )
            custom.Type("anything");
            element = ReadOnly;
            value = custom.GetValue(element);

        }

    }
}
