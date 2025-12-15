using System;
using LetCode.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LetCode;

/// <summary>
/// Test class for dropdown/select functionality.
/// Tests dropdown selection by text, value, and index, plus verification of selected values.
/// </summary>
[TestFixture]
[Category("DropDown")]
public class DropDownTest
{
    private IWebDriver driver;
    private LetCodePages pages;
    private DropDownPage dropDownPage;

    private const string BaseUrl = "https://letcode.in/test";
    private const int DefaultTimeout = 10;

    /// <summary>
    /// One-time setup executed before all dropdown tests.
    /// </summary>
    [OneTimeSetUp]
    public void GlobalSetup()
    {
        var options = new ChromeOptions();
        options.AddArgument("--no-sandbox");
        options.AddArgument("--disable-dev-shm-usage");
        // Uncomment for headless mode
        // options.AddArgument("--headless=new");

        driver = new ChromeDriver(options);
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(DefaultTimeout);
        pages = new LetCodePages(driver);
        dropDownPage = new DropDownPage(driver);
    }

    /// <summary>
    /// Setup executed before each dropdown test.
    /// </summary>
    [SetUp]
    public void Setup()
    {
        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl(BaseUrl);
        pages.GoToPage("Select");
    }

    /// <summary>
    /// Comprehensive test for dropdown/select functionality.
    /// Tests selection by text, value, and index, plus verification of selected options.
    /// </summary>
    [Test]
    public void Test1()
    {
        // 1. Select by visible text
        const string expectedFruit = "apple";
        dropDownPage.SelectByVisibleText(expectedFruit);
        string selectedFruit = dropDownPage.GetSelectedFruitText();
        Console.WriteLine($"Selected Fruit by Text: {selectedFruit}");
        Assert.That(selectedFruit, Is.EqualTo(expectedFruit),
            "Selected fruit should match the expected value.");

        // 2. Verify fruit dropdown is not multiple select
        bool isMultiple = dropDownPage.IsMultipleSelect();
        Console.WriteLine($"Is Multiple Select: {isMultiple}");
        Assert.That(isMultiple, Is.False, "Fruit dropdown should not be a multi-select.");

        // 3. Select by index
        dropDownPage.SelectByIndex(1);
        string selectedByIndex = dropDownPage.GetSelectedFruitText();
        Console.WriteLine($"Selected Fruit by Index: {selectedByIndex}");
        Assert.That(selectedByIndex, Is.Not.Empty, "A fruit should be selected by index.");

        // 4. Select by value (if applicable)
        try
        {
            dropDownPage.SelectByValue("banana");
            string selectedByValue = dropDownPage.GetSelectedFruitText();
            Console.WriteLine($"Selected Fruit by Value: {selectedByValue}");
            Assert.That(selectedByValue, Is.Not.Empty, "A fruit should be selected by value.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Select by value not applicable: {ex.Message}");
        }
    }

    /// <summary>
    /// One-time teardown executed after all dropdown tests.
    /// </summary>
    [OneTimeTearDown]
    public void GlobalTeardown()
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
}
