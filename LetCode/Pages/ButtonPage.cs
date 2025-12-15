using System;
using LetCode.Utils;
using OpenQA.Selenium;
using System.Drawing;

namespace LetCode.Pages
{
    /// <summary>
    /// Page object for the Button test page at letcode.in/test.
    /// Encapsulates interactions with various button elements and their properties.
    /// </summary>
    public class ButtonPage
    {
        private readonly IWebDriver driver;
        private readonly CustomMethod custom;

        /// <summary>
        /// Initializes the button page with a web driver.
        /// </summary>
        public ButtonPage(IWebDriver driver)
        {
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            this.custom = new CustomMethod(this.driver);
        }

        private IWebElement HomeButton => driver.FindElement(By.XPath("//button[@id='home']"));
        private IWebElement ButtonLocation => driver.FindElement(By.XPath("//button[@class='button is-link is-outlined']"));
        private IWebElement ButtonColor => driver.FindElement(By.XPath("//button[@id='color']"));
        private IWebElement ButtonSize => driver.FindElement(By.Id("property"));
        private IWebElement ButtonDisabled => driver.FindElement(By.XPath("//button[@class='button is-info']"));
        private IWebElement ButtonHold => driver.FindElement(By.XPath("//button[@id='isDisabled' and @class='button is-primary']"));
        private IWebElement ButtonHoldText => driver.FindElement(By.XPath("//*[@id='isDisabled']//h2"));

        /// <summary>
        /// Navigates to home page by clicking the home button.
        /// </summary>
        public void GoToHomePageThenGoBack()
        {
            custom.ClickOn(HomeButton);
        }

        /// <summary>
        /// Gets the location coordinates of the button element.
        /// </summary>
        public Point GetButtonLocation()
        {
            return custom.Location(ButtonLocation);
        }

        /// <summary>
        /// Gets the background color CSS value of the button.
        /// </summary>
        public string GetButtonColor()
        {
            return ButtonColor.GetCssValue("background-color") ?? string.Empty;
        }

        /// <summary>
        /// Gets the width and height CSS values of the button.
        /// </summary>
        public (string Width, string Height) GetButtonSize()
        {
            string width = ButtonSize.GetCssValue("width") ?? string.Empty;
            string height = ButtonSize.GetCssValue("height") ?? string.Empty;
            return (width, height);
        }

        /// <summary>
        /// Checks if the disabled button is enabled.
        /// </summary>
        public bool IsButtonEnabled()
        {
            return custom.IsItEnabled(ButtonDisabled);
        }

        /// <summary>
        /// Holds down a button for 3 seconds using the Actions API.
        /// </summary>
        public void HoldButton()
        {
            custom.Hold(ButtonHold);
        }

        /// <summary>
        /// Gets the text that appears after holding the button.
        /// </summary>
        public string GetButtonHoldText()
        {
            return ButtonHoldText.Text ?? string.Empty;
        }
    }
}
