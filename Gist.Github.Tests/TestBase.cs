using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Gist.Github.Tests;

[TestFixture]
public abstract class TestBase
{
    private IWebDriver _driver = null!;
    private WebDriverWait _wait = null!;
    private IJavaScriptExecutor _js = null!;
    
    [SetUp]
    public void SetUp()
    {
        _driver = new ChromeDriver();
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        _js = (IJavaScriptExecutor) _driver;
    }
    
    [TearDown]
    protected void TearDown()
    {
        Thread.Sleep(3000);

        _driver.Close();
        _driver.Quit();
    }

    protected void Login(AccountData user)
    {
        _driver
            .FindElement(By.LinkText("Sign in"))
            .Click();
        _wait
            .Until(d => d.FindElement(By.Id("login_field")))
            .SendKeys(user.Username);
        _driver
            .FindElement(By.Id("password"))
            .SendKeys(user.Password);
        _driver
            .FindElement(By.Name("commit"))
            .Click();
    }

    protected void OpenHomePage()
    {
        _driver
            .Navigate()
            .GoToUrl("https://gist.github.com/starred");
    }

    protected void OpenNewGistPage()
    {
        _driver
            .Navigate()
            .GoToUrl("https://gist.github.com/");
    }

    protected void CreateGist(Gist gist)
    {
        _wait
            .Until(d => d.FindElement(By.Name("gist[contents][][name]")))
            .SendKeys(gist.FileName);

        if (gist.Description is not null)
        {
            _driver
                .FindElement(By.Name("gist[description]"))
                .SendKeys(gist.Description);
        }
        var element = _driver.FindElement(By.Name("gist[contents][][value]"));
        _js.ExecuteScript("arguments[0].style.display = 'block'", element);
        element.SendKeys(gist.Content);
        
        _driver.FindElement(By.CssSelector(".hx_create-pr-button")).Click();
    }
}