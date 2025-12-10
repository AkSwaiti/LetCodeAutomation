using LetCode.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace LetCode
{
    public class MainTest
    {
        private IWebDriver driver;
        private LetCodePages pages;
        private Edit test;
        private Actions action;

        public MainTest()
        {
            driver = new ChromeDriver();
            pages = new LetCodePages(driver);
            test = new Edit(driver);
            action = new Actions(driver);
        }

        [SetUp]
        public void Setup()
        {
            driver.Manage().Window.Maximize();
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
            }
        }
    }
}
