using LetCode.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace LetCode
{
    public class MainTest
    {
        IWebDriver driver;
        private LetCodePages pages;
        private Edit test;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://letcode.in/test");

            pages = new LetCodePages(driver);
            test = new Edit(driver);
        }

        [Test]
        public void Test1()
        {
            pages.GoToPage("Edit");
            test.EnterFullName("ahmad alswaiti");
            string actual = test.Name.GetAttribute("value");
            Console.WriteLine(actual);
            Assert.That(actual, Is.EqualTo("ahmad alswaiti"));
            test.AddText(" enough");
            Assert.That(driver.SwitchTo().ActiveElement, Is.EqualTo(test.GetData));
            test.Gettext();
            Assert.That(test.Gettext, Is.EqualTo("ortonikc"));
            test.RemoveText();
            Assert.That(test.ClearText.GetAttribute("value"), Is.EqualTo(string.Empty));
            if (test.CheckFieldIfItsEnabled() == true)
            {
                Assert.That(test.CheckFieldIfItsEnabled(), Is.True);
                Console.WriteLine("This Field is not Disabled");
            }
            else
            {
                Assert.That(test.CheckFieldIfItsEnabled(), Is.False);
                Console.WriteLine("This Field is Disabled");
            }
            if (test.CheckFieldIfItsReadOnly() != false)
            {
                Assert.That(test.CheckFieldIfItsReadOnly(), Is.True);
                Console.WriteLine(test.GetText());
            }
            else
            {
                Assert.That(test.CheckFieldIfItsReadOnly(), Is.False);
                Console.WriteLine("this field is not readonly");
            }
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
