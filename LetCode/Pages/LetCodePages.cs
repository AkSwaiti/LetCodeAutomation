using LetCode.Utils;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace LetCode.Pages
{
    public class LetCodePages
    {
        private IWebDriver driver;
        private CustomMethod Custom;
        private Dictionary<string, By> Elements;

        public LetCodePages(IWebDriver driver)
        {
            this.driver = driver;
            this.Custom = new CustomMethod(driver);

            Elements = new Dictionary<string, By>
            {
                { "POM", By.XPath("//a[normalize-space()='Page Object Model']") },
                { "Edit", By.XPath("//a[normalize-space()='Edit']") },
                { "Click", By.XPath("//a[normalize-space()='Click']") },
                { "Select", By.XPath("//a[normalize-space()='Drop-Down']") },
                { "Alert", By.XPath("//a[normalize-space()='Dialog']") },
                { "Frame", By.XPath("//a[normalize-space()='Inner HTML']") },
                { "Radio", By.XPath("//a[normalize-space()='Toggle']") },
                { "Window", By.XPath("//a[normalize-space()='Tabs']") },
                { "Element", By.XPath("//a[normalize-space()='Find Elements']") },
                { "Drag", By.XPath("//a[normalize-space()='AUI - 1']") },
                { "Drop", By.XPath("//a[normalize-space()='AUI - 2']") },
                { "Sort", By.XPath("//a[normalize-space()='AUI - 3']") },
                { "MultiSelect", By.XPath("//a[normalize-space()='AUI - 4']") },
                { "Slider", By.XPath("//a[normalize-space()='AUI - 5']") },
                { "Waits", By.XPath("//a[normalize-space()='Timeout']") },
                { "SimpleTable", By.XPath("//a[normalize-space()='Simple table']") },
                { "AdvanceTable", By.XPath("//a[normalize-space()='Advance table']") },
                { "DatePicker", By.XPath("//a[normalize-space()='Date & Time']") },
                { "Form", By.XPath("//a[normalize-space()='All in One']") },
                { "File", By.XPath("//a[normalize-space()='File management']") },
                { "Shadow", By.XPath("//a[normalize-space()='DOM']") }
            };
        }

        public IWebElement GetPage(string pageName)
        {
            return driver.FindElement(Elements[pageName]);
        }

        public void GoToPage(string pageName)
        {
            Custom.ClickOn(GetPage(pageName));
        }
    }
}
