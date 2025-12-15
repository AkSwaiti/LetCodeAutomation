using System;
using System.Collections.Generic;
using LetCode.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace LetCode.Pages
{
    /// <summary>
    /// Page object for the DropDown/Select test page at letcode.in/test.
    /// Encapsulates interactions with select elements and their options.
    /// </summary>
    public class DropDownPage
    {
        private readonly IWebDriver driver;
        private readonly CustomMethod custom;

        /// <summary>
        /// Initializes the dropdown page with a web driver.
        /// </summary>
        public DropDownPage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            this.custom = new CustomMethod(this.driver);
        }

        private IWebElement FruitDropDown => driver.FindElement(By.Id("fruits"));
        private IWebElement SuperherosDropDown => driver.FindElement(By.Id("superheros"));
        private IWebElement LangDropDown => driver.FindElement(By.Id("lang"));
        private IWebElement CountryDropDown => driver.FindElement(By.Id("Country"));

        /// <summary>
        /// Selects a fruit option by visible text.
        /// </summary>
        public void SelectByVisibleText(string text)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentException("Text must not be null or empty.", nameof(text));
            
            custom.SelectByText(FruitDropDown, text);
        }

        /// <summary>
        /// Selects a fruit option by value attribute.
        /// </summary>
        public void SelectByValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("Value must not be null or empty.", nameof(value));
            
            custom.SelectByValue(FruitDropDown, value);
        }

        /// <summary>
        /// Selects a fruit option by index.
        /// </summary>
        public void SelectByIndex(int index)
        {
            if (index < 0)
                throw new ArgumentException("Index must be non-negative.", nameof(index));
            
            custom.SelectByIndex(FruitDropDown, index);
        }

        /// <summary>
        /// Gets the currently selected fruit option text.
        /// </summary>
        public string GetSelectedFruitText()
        {
            return custom.GetSelectedOptionText(FruitDropDown);
        }

        /// <summary>
        /// Gets all selected fruit options' text (relevant for multi-select).
        /// </summary>
        public IReadOnlyList<string> GetAllSelectedFruitTexts()
        {
            return custom.GetAllSelectedOptionsText(FruitDropDown);
        }

        /// <summary>
        /// Checks if the fruit dropdown supports multiple selections.
        /// </summary>
        public bool IsMultipleSelect()
        {
            return custom.IsMultiple(FruitDropDown);
        }

        /// <summary>
        /// Selects a superhero option by visible text.
        /// </summary>
        public void SelectSuperheroByText(string text)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentException("Text must not be null or empty.", nameof(text));
            
            custom.SelectByText(SuperherosDropDown, text);
        }

        /// <summary>
        /// Gets the currently selected superhero option text.
        /// </summary>
        public string GetSelectedSuperheroText()
        {
            return custom.GetSelectedOptionText(SuperherosDropDown);
        }

        /// <summary>
        /// Selects a programming language by visible text.
        /// </summary>
        public void SelectLanguageByText(string text)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentException("Text must not be null or empty.", nameof(text));
            
            custom.SelectByText(LangDropDown, text);
        }

        /// <summary>
        /// Gets the currently selected language option text.
        /// </summary>
        public string GetSelectedLanguageText()
        {
            return custom.GetSelectedOptionText(LangDropDown);
        }

        /// <summary>
        /// Selects a country by visible text.
        /// </summary>
        public void SelectCountryByText(string text)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentException("Text must not be null or empty.", nameof(text));
            
            custom.SelectByText(CountryDropDown, text);
        }

        /// <summary>
        /// Gets the currently selected country option text.
        /// </summary>
        public string GetSelectedCountryText()
        {
            return custom.GetSelectedOptionText(CountryDropDown);
        }
    }
}
