using System;
using LetCode.Utils;
using OpenQA.Selenium;

namespace LetCode.Pages
{
<<<<<<< HEAD:LetCode/Pages/EditPage.cs
    /// <summary>
    /// Page object for the Edit test page at letcode.in/test.
    /// Encapsulates interactions with input fields and their properties.
    /// </summary>
    public class EditPage
=======
    class Edit
>>>>>>> parent of 600816b (end of button test):LetCode/Pages/Edit.cs
    {
        private readonly IWebDriver driver;
        private readonly CustomMethod custom;

<<<<<<< HEAD:LetCode/Pages/EditPage.cs
        /// <summary>
        /// Initializes the edit page with a web driver.
        /// </summary>
        public EditPage(IWebDriver driver)
=======
        public Edit(IWebDriver driver)
>>>>>>> parent of 600816b (end of button test):LetCode/Pages/Edit.cs
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            this.custom = new CustomMethod(this.driver);
        }

        public IWebElement Name => driver.FindElement(By.Id("fullName"));
        public IWebElement TextAndTab => driver.FindElement(By.Id("join"));
        public IWebElement GetData => driver.FindElement(By.Id("getMe"));
        public IWebElement ClearText => driver.FindElement(By.Id("clearMe"));
        private IWebElement DisabledField => driver.FindElement(By.Id("noEdit"));
        public IWebElement ReadOnly => driver.FindElement(By.Id("dontwrite"));

        /// <summary>
        /// Enters a full name into the full name input field.
        /// </summary>
        public void EnterFullName(string fullName)
        {
            if (string.IsNullOrEmpty(fullName))
                throw new ArgumentException("Full name must not be null or empty.", nameof(fullName));
            
            custom.Type(Name, fullName);
        }

        /// <summary>
        /// Adds text to the join/tab test field.
        /// </summary>
        public void AddText(string text)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentException("Text must not be null or empty.", nameof(text));
            
            custom.Type(TextAndTab, text);
        }

        /// <summary>
        /// Gets the value from the data field.
        /// </summary>
        public string GetTextValue()
        {
            return custom.GetValue(GetData);
        }

        /// <summary>
        /// Clears the text from the clear text field.
        /// </summary>
        public void RemoveText()
        {
            custom.ClearField(ClearText);
        }

        /// <summary>
        /// Checks if the disabled field is enabled.
        /// </summary>
        public bool IsDisabledFieldEnabled()
        {
            return custom.IsItEnabled(DisabledField);
        }

        /// <summary>
        /// Gets the value of the read-only field.
        /// </summary>
        public string GetReadOnlyValue()
        {
            return custom.GetValue(ReadOnly);
        }

        /// <summary>
        /// Checks if the read-only field has the readonly attribute.
        /// </summary>
        public bool IsReadOnlyFieldReadOnly()
        {
            string attr = ReadOnly.GetAttribute("readonly") ?? string.Empty;
            return !string.IsNullOrEmpty(attr) && (attr.Equals("true") || attr.Equals("readonly"));
        }
    }
}
