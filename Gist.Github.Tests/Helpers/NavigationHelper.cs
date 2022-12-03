using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Gist.Github.Helpers;

public sealed class NavigationHelper : HelperBase
{
    private readonly string _baseUrl;

    public NavigationHelper(IWebDriver driver, WebDriverWait wait, IJavaScriptExecutor javaScriptExecutor)
        : base(driver, wait, javaScriptExecutor)
    {
        _baseUrl = Settings.BaseUrl;
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