using System;
using System.Drawing;
using LetCode.Base;
using LetCode.Pages;
using NUnit.Framework;

namespace LetCode.Tests
{
    /// <summary>
    /// Test class for button page functionality.
    /// Tests button interactions including navigation, styling, size, state, and hold actions.
    /// </summary>
    [TestFixture]
    [Category("Button")]
    public class ButtonTest : BaseTest
    {
        private ButtonPage buttonPage;

        /// <summary>
        /// Setup executed before each button test.
        /// </summary>
        [SetUp]
        public override void Setup()
        {
            base.Setup();
            buttonPage = new ButtonPage(driver);
        }

        /// <summary>
        /// Comprehensive test for all button page functionality.
        /// Tests button navigation, location, color, size, state, and hold actions.
        /// </summary>
        [Test]
        public void TestButtons()
        {
            // Navigate to Click page
            pages.GoToPage("Click");

            // 1. Test Home Button Navigation
            buttonPage.GoToHomePageThenGoBack();
            bool pageReturned = driver.PageSource.Contains("LetCode with Koushik");
            Assert.That(pageReturned, Is.True, "Button should return to the home page.");
            driver.Navigate().Back();

            // 2. Get the Button Location (Coordinates)
            Point location = buttonPage.GetButtonLocation();
            Console.WriteLine($"Button Location: X={location.X}, Y={location.Y}");
            Assert.That(location.X, Is.EqualTo(124), "Button X coordinate should match.");
            Assert.That(location.Y, Is.EqualTo(336), "Button Y coordinate should match.");

            // 3. Get the Color of the Button
            string color = buttonPage.GetButtonColor();
            Console.WriteLine($"Button Color: {color}");
            Assert.That(color, Is.EqualTo("rgba(42, 157, 144, 1)"), "Button color should match expected RGB value.");

            // 4. Get the Height & Width of the Button
            var (width, height) = buttonPage.GetButtonSize();
            Console.WriteLine($"Button Size - Width: {width}, Height: {height}");
            Assert.That(width, Is.EqualTo("174.219px"), "Button width should be 174.219px.");
            Assert.That(height, Is.EqualTo("40px"), "Button height should be 40px.");

            // 5. Check if the Button is Disabled
            bool isEnabled = buttonPage.IsButtonEnabled();
            Console.WriteLine($"Button Enabled: {isEnabled}");
            Assert.That(isEnabled, Is.False, "Button should be disabled.");

            // 6. Click and Hold Button For 3 Seconds
            buttonPage.HoldButton();
            string result = buttonPage.GetButtonHoldText();
            Console.WriteLine($"Button Hold Result: {result}");
            Assert.That(result, Is.EqualTo("Button has been long pressed"), 
                "Button hold should produce expected message.");
        }
    }
}
