using LetCode.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LetCode.Base
{
    public class BaseTest
    {
        protected IWebDriver driver;
        protected LetCodePages page;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            driver = new ChromeDriver();
            page = new LetCodePages(driver);
        }

        [SetUp]
        public void Setup()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://letcode.in/test");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
