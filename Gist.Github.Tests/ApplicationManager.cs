using Gist.Github.Tests.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Gist.Github.Tests;

public sealed class ApplicationManager
{
    public ApplicationManager()
    {
        _driver = new ChromeDriver();
        _driver.Manage().Window.Maximize();
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        var js = (IJavaScriptExecutor) _driver;

        const string baseUrl = "https://gist.github.com";
        Navigation = new NavigationHelper(_driver, wait, js, baseUrl);
        Auth = new AuthHelper(_driver, wait, js);
        Gist = new GistHelper(_driver, wait, js);
    }

    public void Stop()
    {
        Thread.Sleep(3000);

        _driver.Close();
        _driver.Quit();
    }
    
    public NavigationHelper Navigation { get; }

    public AuthHelper Auth { get; }

    public GistHelper Gist { get; }

    private readonly IWebDriver _driver;
}