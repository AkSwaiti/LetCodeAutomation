using System.Drawing;
using LetCode.Base;
using LetCode.Pages;


namespace LetCode.Tests
{
    [TestFixture]
    [Category("Button")]
    public class ButtonTest : BaseTest
    {
        [Test]
        public void TestButtons()
        {
            var test = new ButtonPage(driver);

            // 1. Go To Home Page Then Return Back
            page.GoToPage("Click");
            test.GoToHomePageThenGoback();
            bool contains = driver.PageSource.Contains("LetCode with Koushik");
            Assert.That(contains, Is.True, contains ? "The button returned to the home page!" : "The button did NOT return to the home page.");
            driver.Navigate().Back();

            // Get the Button Coordinates
            Point point = test.GetButtonLocation();
            Console.WriteLine(point.X + " " + point.Y);
            Assert.That(point.X, Is.EqualTo(124), "Button X coordinate is incorrect");
            Assert.That(point.Y, Is.EqualTo(336), "Button Y coordinate is incorrect");

            // Get the Color of the Button
            string color = test.GetButtonColor();
            Console.WriteLine(color);
            Assert.That(color, Is.EqualTo("rgba(42, 157, 144, 1)"), color == "rgba(42, 157, 144, 1)" ? "The Color is correct" : "Wrong color");
            // Get the height & width of the button
            var (width, height) = test.GetButtonSize();
            Console.WriteLine(width);
            Console.WriteLine(height);
            Assert.That(width, Is.EqualTo("40px"), width == "40px" ?  "The width is not correct" : "The width is correct " + width);
            Assert.That(height, Is.EqualTo("174.219px"), height == "174.219px" ? "The height is correct " + height : "The height is not correct");
            // Check if the button is disable 
            bool CheckIfButtonDisabled =test.CheckButton();
            Assert.IsTrue(CheckIfButtonDisabled == false, "The Button is Disabled");
            // Click and Hold Button For 3 Seconds
            test.HoldButton(); 
            string result = test.GetButtonHoldText(); 
            Console.WriteLine(result);
            Assert.That(result, Is.EqualTo("Button has been long pressed") ,result == "Button has been long pressed"? "The button has been pressed and held.": "The button has NOT been pressed and held.");


        }
    }
}
