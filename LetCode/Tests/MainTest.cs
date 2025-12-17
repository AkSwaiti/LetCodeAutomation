<<<<<<< HEAD
using System;
using LetCode.Pages;
using NUnit.Framework;
=======
using LetCode.Pages;
>>>>>>> parent of 600816b (end of button test)
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace LetCode.Tests
{
<<<<<<< HEAD
<<<<<<< HEAD:LetCode/Tests/TestEdit.cs
    /// <summary>
    /// Test class for edit page functionality.
    /// Tests input field interactions including typing, tab navigation, clearing, and field states.
    /// </summary>
    [TestFixture]
    [Category("Edit")]
    public class TestEdit
    {
        private IWebDriver driver;
        private LetCodePages pages;
        private EditPage editPage;
        private Actions actions;

        private const string BaseUrl = "https://letcode.in/test";
        private const int DefaultTimeout = 10;

        /// <summary>
        /// One-time setup executed before all edit tests.
        /// </summary>
        [OneTimeSetUp]
        public void GlobalSetup()
=======
=======
>>>>>>> parent of 600816b (end of button test)
    public class MainTest
    {
        private IWebDriver driver;
        private LetCodePages pages;
        private Edit test;
        private Actions action;

        public MainTest()
<<<<<<< HEAD
>>>>>>> parent of 600816b (end of button test):LetCode/Tests/MainTest.cs
        {
            var options = new ChromeOptions();
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");

            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(DefaultTimeout);
            pages = new LetCodePages(driver);
<<<<<<< HEAD:LetCode/Tests/TestEdit.cs
            editPage = new EditPage(driver);
            actions = new Actions(driver);
=======
            test = new Edit(driver);
            action = new Actions(driver);
>>>>>>> parent of 600816b (end of button test):LetCode/Tests/MainTest.cs
        }

        /// <summary>
        /// Setup executed before each edit test.
        /// </summary>
=======
        {
            driver = new ChromeDriver();
            pages = new LetCodePages(driver);
            test = new Edit(driver);
            action = new Actions(driver);
        }

>>>>>>> parent of 600816b (end of button test)
        [SetUp]
        public void Setup()
        {
            driver.Manage().Window.Maximize();
<<<<<<< HEAD
            driver.Navigate().GoToUrl(BaseUrl);
            pages.GoToPage("Edit");
        }

        /// <summary>
        /// Comprehensive test for all edit page field interactions.
        /// Tests text input, tab navigation, field clearing, and field states.
        /// </summary>
        [Test]
        public void Test1()
        {
            // 1. Enter full name
            const string expectedName = "ahmad alswaiti";
            editPage.EnterFullName(expectedName);
            string fullNameValue = editPage.Name.GetAttribute("value");
            Console.WriteLine($"Full Name Entered: {fullNameValue}");
            Assert.That(fullNameValue, Is.EqualTo(expectedName), "Full name did not match.");

            // 2. Add text and press TAB
            editPage.AddText(" enough");
            actions.SendKeys(Keys.Tab).Perform();
            string dataValue = editPage.GetData.GetAttribute("value");
            Console.WriteLine($"Data Value After TAB: {dataValue}");
            Assert.That(dataValue, Is.EqualTo("ortonikc"), "Data field did not return expected value.");

            // 3. Remove text from ClearMe field
            editPage.RemoveText();
            string clearedValue = editPage.ClearText.GetAttribute("value");
            Console.WriteLine($"Cleared Field Value: {clearedValue}");
            Assert.That(clearedValue, Is.EqualTo(string.Empty), "ClearText field was not cleared.");

            // 4. Check if the Disabled field is enabled
            bool isDisabledFieldEnabled = editPage.IsDisabledFieldEnabled();
            Console.WriteLine($"Disabled Field Enabled: {isDisabledFieldEnabled}");
            Assert.That(isDisabledFieldEnabled, Is.False, "Disabled field check failed.");

            // 5. Check if the ReadOnly field is readonly
            bool isReadOnly = editPage.IsReadOnlyFieldReadOnly();
            Console.WriteLine($"ReadOnly Field is ReadOnly: {isReadOnly}");
            Assert.That(isReadOnly, Is.True, "ReadOnly field was not readonly as expected.");
        }

<<<<<<< HEAD:LetCode/Tests/TestEdit.cs
        /// <summary>
        /// One-time teardown executed after all edit tests.
        /// </summary>
        [OneTimeTearDown]
=======
        [TearDown]
>>>>>>> parent of 600816b (end of button test):LetCode/Tests/MainTest.cs
        public void Cleanup()
        {
            try
            {
                driver?.Quit();
            }
            finally
            {
                driver?.Dispose();
=======
            driver.Navigate().GoToUrl("https://letcode.in/test");
        }

        [Test]
        public void Test1()
        {
            // Navigate to Edit Page
            pages.GoToPage("Edit");

            // 1. Enter full name
            test.EnterFullName("ahmad alswaiti");
            string fullNameValue = test.Name.GetAttribute("value");
            Console.WriteLine(fullNameValue);
            Assert.That(fullNameValue, Is.EqualTo("ahmad alswaiti"), "Full name did not match.");

            // 2. Add text and press TAB
            test.AddText(" enough");
            action.SendKeys(Keys.Tab).Perform();

            // Assert value populated after TAB
            string dataValue = test.GetData.GetAttribute("value");
            Console.WriteLine(dataValue);
            Assert.That(dataValue, Is.EqualTo("ortonikc"), "Data field did not return expected value.");

            // 3. Remove text from ClearMe field
            test.RemoveText();
            Assert.That(test.ClearText.GetAttribute("value"), Is.EqualTo(string.Empty), "ClearText field was not cleared.");

            // 4. Check if the Disabled field is enabled
            bool isEnabled = test.CheckFieldIfItsEnabled();
            Console.WriteLine(isEnabled ? "This field is not disabled." : "This field is disabled.");
            Assert.That(isEnabled, Is.EqualTo(false), "Disabled field check failed.");

            // 5. Check if the ReadOnly field is readonly
            bool isReadOnly = test.CheckFieldIfItsReadOnly();
            Console.WriteLine(isReadOnly ? "Field is read-only." : "Field is NOT read-only.");
            Assert.That(isReadOnly, Is.EqualTo(true), "ReadOnly field was not readonly as expected.");
        }

        [TearDown]
        public void Cleanup()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
>>>>>>> parent of 600816b (end of button test)
            }
        }
    }
}
