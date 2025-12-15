using System;
using LetCode.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace LetCode.Base
{
    /// <summary>
    /// Base test fixture for all Selenium test classes.
    /// Provides shared setup and teardown for WebDriver initialization and browser navigation.
    /// Implements the Template Method pattern for test lifecycle management.
    /// </summary>
    [TestFixture]
    public abstract class BaseTest : IDisposable
    {
        protected IWebDriver driver;
        protected LetCodePages pages;

        protected const string BaseUrl = "https://letcode.in/test";
        protected const int DefaultTimeout = 10;

        /// <summary>
        /// One-time setup executed before all tests in the fixture.
        /// Initializes the Chrome WebDriver with optimal settings.
        /// </summary>
        [OneTimeSetUp]
        public virtual void OneTimeSetup()
        {
            var options = new ChromeOptions();
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            // Uncomment for headless mode
            // options.AddArgument("--headless=new");

            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(DefaultTimeout);
            pages = new LetCodePages(driver);
        }

        /// <summary>
        /// Setup executed before each test.
        /// Maximizes the browser window and navigates to the base URL.
        /// </summary>
        [SetUp]
        public virtual void Setup()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(BaseUrl);
        }

        /// <summary>
        /// Teardown executed after each test.
        /// Can be overridden by derived classes for additional cleanup.
        /// </summary>
        [TearDown]
        public virtual void TearDown()
        {
            // Override in derived classes if needed
        }

        /// <summary>
        /// One-time teardown executed after all tests in the fixture.
        /// Safely closes the WebDriver and releases resources.
        /// </summary>
        [OneTimeTearDown]
        public virtual void OneTimeTearDown()
        {
            try
            {
                driver?.Quit();
            }
            finally
            {
                driver?.Dispose();
            }
        }

        /// <summary>
        /// Disposes the WebDriver resource.
        /// </summary>
        public void Dispose()
        {
            driver?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
