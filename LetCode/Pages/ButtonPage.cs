using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LetCode.Utils;
using OpenQA.Selenium;
using System.Drawing;
using OpenQA.Selenium.Interactions;


namespace LetCode.Pages
{
    public class ButtonPage
    {
        IWebDriver driver;
        CustomMethod custom;

        public ButtonPage(IWebDriver _driver)
        {
            this.driver = _driver;
            custom = new CustomMethod(driver);
        }
        //Elements in Button Page
        private IWebElement HomeButton => driver.FindElement(By.XPath("//button[@id='home']"));
        private IWebElement ButtonLocation => driver.FindElement(By.XPath("//button[@class ='button is-link is-outlined']"));
        private IWebElement ButtonColor => driver.FindElement(By.XPath("//button[@id='color']"));
        private IWebElement ButtonSize => driver.FindElement(By.Id("property"));
        private IWebElement ButtonDisabled => driver.FindElement(By.XPath("//button[@class='button is-info']"));
        private IWebElement ButtonHold => driver.FindElement(By.XPath("//button[@id='isDisabled' and @class='button is-primary']"));
        private IWebElement ButtonHoldText => driver.FindElement(By.XPath("//*[@id=\"isDisabled\"]//h2"));

        //Go to home then return back method
        public void GoToHomePageThenGoback()
        {
            custom.ClickOn(HomeButton);
            //driver.Navigate().Back();

        }
        public Point GetButtonLocation()
        {
            return ButtonLocation.Location;
        }
        public string GetButtonColor()
        {
            return ButtonColor.GetCssValue("background-color");
        }
        public (string width, string height)  GetButtonSize()
        {
            string  height = ButtonSize.GetCssValue("width");
              string width = ButtonSize.GetCssValue("height");
            return (width , height);
   
        }
        public bool CheckButton()
        {
            return ButtonDisabled.Enabled;
        }
        public void HoldButton()
        {
            custom.Hold(ButtonHold);
        }

        public string GetButtonHoldText()
        {
            return ButtonHoldText.Text;
        }

    }
}
