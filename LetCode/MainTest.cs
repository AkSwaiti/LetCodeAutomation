using LetCode.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;


namespace LetCode
{
    public class MainTest
    {
        IWebDriver driver;
        private LetCodePages pages;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://letcode.in/test");

            pages = new LetCodePages(driver); 
        }

        [Test]
        public void Test1()
        {
            pages.GoToPage("Edit");
            Thread.Sleep(10000);
        }

        [TearDown]
        public void Cleanup()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
            
        }
    }
}
