using LetCode.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace LetCode.Pages
{
    /// <summary>
    /// Navigation hub for all test pages available on the letcode.in site.
    /// Uses page object model pattern with locators stored in a dictionary.
    /// </summary>
    public class LetCodePages
    {
        private readonly IWebDriver driver;
        private readonly CustomMethod custom;
        private readonly Dictionary<string, By> pageLocators;

        /// <summary>
        /// Initializes the navigation hub with a web driver.
        /// </summary>
        public LetCodePages(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            this.custom = new CustomMethod(this.driver);

            pageLocators = new Dictionary<string, By>
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

        /// <summary>
        /// Navigates to the specified page by name.
        /// </summary>
        /// <param name="pageName">The page name key (e.g., "Edit", "Click", "Select")</param>
        /// <exception cref="KeyNotFoundException">Thrown if page name is not found.</exception>
        public void GoToPage(string pageName)
        {
            if (string.IsNullOrEmpty(pageName))
                throw new ArgumentException("Page name must not be null or empty.", nameof(pageName));

            if (!pageLocators.TryGetValue(pageName, out var locator))
                throw new KeyNotFoundException($"Page '{pageName}' not found in page registry.");

            var pageLink = custom.WaitUntilClickable(locator);
            custom.ClickOn(pageLink);
        }
    }
}
