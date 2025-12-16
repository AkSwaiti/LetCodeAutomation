<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using OpenQA.Selenium;
=======
﻿using OpenQA.Selenium;
>>>>>>> parent of 600816b (end of button test)
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;       

namespace LetCode.Utils
{
    /// <summary>
    /// Lightweight collection of reusable Selenium helper utilities used across page objects.
    /// Provides safe guards, common SelectElement helpers and basic wait helpers.
    /// </summary>
    public sealed class CustomMethod
    {
        private readonly IWebDriver driver;
        private readonly Actions actions;
        private readonly TimeSpan defaultTimeout = TimeSpan.FromSeconds(10);

        public CustomMethod(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            this.actions = new Actions(this.driver);
        }

        /// <summary>
        /// Clicks the provided element.
        /// </summary>
        public void ClickOn(IWebElement element)
        {
            if (element is null) throw new ArgumentNullException(nameof(element));
            element.Click();
        }

        /// <summary>
        /// Clears the provided input element.
        /// </summary>
        public void ClearField(IWebElement element)
        {
            if (element is null) throw new ArgumentNullException(nameof(element));
            element.Clear();
        }

        /// <summary>
        /// Types text into an input element.
        /// </summary>
        public void Type(IWebElement element, string text)
        {
            if (element is null) throw new ArgumentNullException(nameof(element));
            if (text is null) throw new ArgumentNullException(nameof(text));
            element.SendKeys(text);
        }

        /// <summary>
        /// Returns whether the element is enabled.
        /// </summary>
        public bool IsItEnabled(IWebElement element)
        {
            if (element is null) throw new ArgumentNullException(nameof(element));
            return element.Enabled;
        }

        /// <summary>
        /// Gets the value of the 'title' attribute for an element.
        /// </summary>
        public string GetTitle(IWebElement element)
        {
            if (element is null) throw new ArgumentNullException(nameof(element));
            return element.GetAttribute("title") ?? string.Empty;
        }

        /// <summary>
        /// Gets the value of the 'value' attribute for an element.
        /// </summary>
        public string GetValue(IWebElement element)
        {
            if (element is null) throw new ArgumentNullException(nameof(element));
            return element.GetAttribute("value") ?? string.Empty;
        }
<<<<<<< HEAD

        /// <summary>
        /// Sends one or more keys to the active element (uses the shared Actions instance).
        /// Useful for sending special keys from <see cref="OpenQA.Selenium.Keys"/>.
        /// </summary>
        public void PressOn(string key)
=======
        public void PressOn( string key)
>>>>>>> parent of 600816b (end of button test)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentException("Key must not be null or empty", nameof(key));
            actions.SendKeys(key).Perform();
        }
<<<<<<< HEAD

        /// <summary>
        /// Clicks an element, holds for a brief pause and then releases.
        /// </summary>
        public void Hold(IWebElement element, TimeSpan? holdDuration = null)
        {
            if (element is null) throw new ArgumentNullException(nameof(element));
            var pause = holdDuration ?? TimeSpan.FromSeconds(3);
            actions.ClickAndHold(element).Pause(pause).Release().Perform();
        }

        /// <summary>
        /// Returns the location (Point) of an element on the page.
        /// </summary>
        public Point Location(IWebElement element)
        {
            if (element is null) throw new ArgumentNullException(nameof(element));
            return element.Location;
        }

        // -----------------------
        // SelectElement helpers
        // -----------------------

        /// <summary>
        /// Selects an option by visible text from a select element.
        /// </summary>
        public void SelectByText(IWebElement element, string text)
        {
            if (element is null) throw new ArgumentNullException(nameof(element));
            if (text is null) throw new ArgumentNullException(nameof(text));
            var select = new SelectElement(element);
            select.SelectByText(text);
        }

        /// <summary>
        /// Selects an option by value attribute.
        /// </summary>
        public void SelectByValue(IWebElement element, string value)
        {
            if (element is null) throw new ArgumentNullException(nameof(element));
            if (value is null) throw new ArgumentNullException(nameof(value));
            var select = new SelectElement(element);
            select.SelectByValue(value);
        }

        /// <summary>
        /// Selects an option by index.
        /// </summary>
        public void SelectByIndex(IWebElement element, int index)
        {
            if (element is null) throw new ArgumentNullException(nameof(element));
            var select = new SelectElement(element);
            select.SelectByIndex(index);
        }

        /// <summary>
        /// Returns the visible text of the currently selected option (first if multiple).
        /// </summary>
        public string GetSelectedOptionText(IWebElement element)
        {
            if (element is null) throw new ArgumentNullException(nameof(element));
            var select = new SelectElement(element);
            return select.SelectedOption?.Text ?? string.Empty;
        }

        /// <summary>
        /// Returns all selected options' texts for a multi-select element.
        /// </summary>
        public IReadOnlyList<string> GetAllSelectedOptionsText(IWebElement element)
        {
            if (element is null) throw new ArgumentNullException(nameof(element));
            var select = new SelectElement(element);
            return select.AllSelectedOptions.Select(o => o.Text).ToList().AsReadOnly();
        }

        /// <summary>
        /// Returns whether the underlying select element supports multiple selections.
        /// </summary>
        public bool IsMultiple(IWebElement element)
        {
            if (element is null) throw new ArgumentNullException(nameof(element));
            var select = new SelectElement(element);
            return select.IsMultiple;
        }

        // -----------------------
        // Wait helpers
        // -----------------------

        /// <summary>
        /// Waits until an element located by the provided locator is visible.
        /// </summary>
        public IWebElement WaitUntilVisible(By by, TimeSpan? timeout = null)
        {
            if (by is null) throw new ArgumentNullException(nameof(by));
            var wait = new WebDriverWait(driver, timeout ?? defaultTimeout);
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
        }

        /// <summary>
        /// Waits until an element located by the provided locator is clickable.
        /// </summary>
        public IWebElement WaitUntilClickable(By by, TimeSpan? timeout = null)
        {
            if (by is null) throw new ArgumentNullException(nameof(by));
            var wait = new WebDriverWait(driver, timeout ?? defaultTimeout);
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }

        /// <summary>
        /// Attempts to find an element; returns null instead of throwing if not found within the timeout.
        /// </summary>
        public IWebElement? TryFindElement(By by, TimeSpan? timeout = null)
        {
            try
            {
                return WaitUntilVisible(by, timeout);
            }
            catch (WebDriverTimeoutException)
            {
                return null;
            }
        }
=======
>>>>>>> parent of 600816b (end of button test)
    }
}
