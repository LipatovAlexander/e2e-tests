using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Gist.Github.Tests;

[TestFixture]
public class AuthTest {
    private IWebDriver driver;
    public IDictionary<string, object> vars {get; private set;}
    private IJavaScriptExecutor js;
    
    [SetUp]
    public void SetUp() {
        driver = new ChromeDriver();
        js = (IJavaScriptExecutor)driver;
        vars = new Dictionary<string, object>();
    }
    
    [TearDown]
    protected void TearDown() {
        driver.Quit();
    }
    
    [Test]
    public void Auth() {
        driver.Navigate().GoToUrl("https://gist.github.com/starred");
        driver.Manage().Window.Size = new System.Drawing.Size(947, 816);
        driver.FindElement(By.LinkText("Sign in")).Click();
        Thread.Sleep(1000);
        driver.FindElement(By.Id("login_field")).SendKeys("githubtests-itis");
        driver.FindElement(By.Id("password")).SendKeys("g1thubTests");
        driver.FindElement(By.Name("commit")).Click();
        Thread.Sleep(1000);
        driver.Close();
    }
}