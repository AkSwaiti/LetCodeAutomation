using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetCode.Utils
{
    class CustomMethod
    {
        private IWebDriver driver;
        public CustomMethod(IWebDriver driver)
        {
            this.driver = driver;
        }
        public static void ClickOn(IWebDriver driver, IWebElement click)
            {
            driver.click
            }
    }
}
