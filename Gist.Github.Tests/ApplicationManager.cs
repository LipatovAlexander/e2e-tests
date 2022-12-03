using Gist.Github.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Gist.Github;

public sealed class ApplicationManager : IDisposable
{
    public static ApplicationManager GetInstance()
    {
        if (!StaticApplicationManager.IsValueCreated)
        {
            var newInstance = new ApplicationManager();
            newInstance._navigation.OpenHomePage();
            StaticApplicationManager.Value = newInstance;
        }

        return StaticApplicationManager.Value!;
    }
    
    public void Dispose()
    {
        _driver.Close();
        _driver.Quit();
        _driver.Dispose();
    }
    
    public AuthHelper Auth { get; }

    public GistHelper Gist { get; }

    private readonly NavigationHelper _navigation;
    private readonly IWebDriver _driver;
    private static readonly ThreadLocal<ApplicationManager> StaticApplicationManager = new();
    
    private ApplicationManager()
    {
        _driver = new ChromeDriver();
        _driver.Manage().Window.Maximize();
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        var js = (IJavaScriptExecutor) _driver;

        _navigation = new NavigationHelper(_driver, wait, js);
        
        Auth = new AuthHelper(_driver, wait, js, _navigation);
        Gist = new GistHelper(_driver, wait, js, _navigation);
    }
}