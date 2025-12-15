using LetCode.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LetCode;

public class DropDownTest
{
    private DropDownPage test;
    private IWebDriver driver;
    private LetCodePages page;
    [SetUp]
    public void Setup(IWebDriver driver)
    {
        this.driver = driver;
        page = new ChromeDriver(driver);
    }

    [Test]
    public void Test1()
    {
    }
}
