using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Gist.Github.Tests;

[TestFixture]
public class AuthTest {
    private IWebDriver _driver = null!;
    private WebDriverWait _wait = null!;
    
    [SetUp]
    public void SetUp() {
        _driver = new ChromeDriver();
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
    }
    
    [TearDown]
    protected void TearDown() {
        _driver.Close();
        _driver.Quit();
    }
    
    [Test]
    public void Auth() {
        OpenHomePage();
        Login();
        Thread.Sleep(3000);
    }

    private void Login()
    {
        _driver
            .FindElement(By.LinkText("Sign in"))
            .Click();
        _wait
            .Until(d => d.FindElement(By.Id("login_field")))
            .SendKeys("githubtests-itis");
        _driver
            .FindElement(By.Id("password"))
            .SendKeys("g1thubTests");
        _driver
            .FindElement(By.Name("commit"))
            .Click();
    }

    private void OpenHomePage()
    {
        _driver
            .Navigate()
            .GoToUrl("https://gist.github.com/starred");
    }
}