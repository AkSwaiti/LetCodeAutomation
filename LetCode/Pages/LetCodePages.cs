using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LetCode.Pages
{
    public class LetCodePages
    {
        private IWebDriver driver;
        public LetCodePages(IWebDriver driver)
        {
            this.driver = driver;
        }
        private IWebElement POM => driver.FindElement(By.XPath("//a[normalize-space()='Page Object Model']"));
        private IWebElement Input => driver.FindElement(By.XPath("//a[normalize-space()='Edit']"));
        private IWebElement Button => driver.FindElement(By.XPath("//a[normalize-space()='Click']"));
        private IWebElement Select => driver.FindElement(By.XPath("//a[normalize-space()='Drop-Down']"));
        private IWebElement Alert => driver.FindElement(By.XPath("//a[normalize-space()='Dialog']"));
        private IWebElement Frame => driver.FindElement(By.XPath("//a[normalize-space()='Inner HTML']"));
        private IWebElement Radio => driver.FindElement(By.XPath("//a[normalize-space()='Toggle']"));
        private IWebElement Window => driver.FindElement(By.XPath("//a[normalize-space()='Tabs']"));
        private IWebElement Element => driver.FindElement(By.XPath("//a[normalize-space()='Find Elements']"));
        private IWebElement Drag => driver.FindElement(By.XPath("//a[normalize-space()='AUI - 1']"));
        private IWebElement Drop => driver.FindElement(By.XPath("//a[normalize-space()='AUI - 2']"));
        private IWebElement Sort => driver.FindElement(By.XPath("//a[normalize-space()='AUI - 3']"));
        private IWebElement MultiSelect => driver.FindElement(By.XPath("//a[normalize-space()='AUI - 4']"));
        private IWebElement Slider => driver.FindElement(By.XPath("//a[normalize-space()='AUI - 5']"));
        private IWebElement Waits => driver.FindElement(By.XPath("//a[normalize-space()='Timeout']"));
        private IWebElement Table => driver.FindElement(By.XPath("//a[normalize-space()='Simple table']"));
        private IWebElement AdvancedTable => driver.FindElement(By.XPath("//a[normalize-space()='Advance table']"));
        private IWebElement DatePicker => driver.FindElement(By.XPath("//a[normalize-space()='Date & Time']"));
        private IWebElement Form => driver.FindElement(By.XPath("//a[normalize-space()='All in One']"));
        private IWebElement File => driver.FindElement(By.XPath("//a[normalize-space()='File management']"));
        private IWebElement Shadiw => driver.FindElement(By.XPath("//a[normalize-space()='DOM']"));
        public static void GoToPom()
        {
            
        }

    }
}
