using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Gist.Github.Helpers;

public sealed class NavigationHelper : HelperBase
{
    private readonly string _baseUrl;

    public NavigationHelper(IWebDriver driver, WebDriverWait wait, IJavaScriptExecutor javaScriptExecutor, string baseUrl)
        : base(driver, wait, javaScriptExecutor)
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

    public void OpenGistPage(string username, string gistId)
    {
        Driver
            .Navigate()
            .GoToUrl($"{_baseUrl}/{username}/{gistId}");
    }
}