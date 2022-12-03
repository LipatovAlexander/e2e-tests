using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Gist.Github.Tests.Helpers;

public sealed class NavigationHelper : HelperBase
{
    private readonly string _baseUrl;

    public NavigationHelper(IWebDriver driver, WebDriverWait wait, IJavaScriptExecutor javaScriptExecutor, string baseUrl) : base(driver, wait, javaScriptExecutor)
    {
        _baseUrl = baseUrl;
    }

    public void OpenHomePage()
    {
        Driver
            .Navigate()
            .GoToUrl($"{_baseUrl}/starred");
    }

    public void OpenNewGistPage()
    {
        Driver
            .Navigate()
            .GoToUrl(_baseUrl);
    }
}