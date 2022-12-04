using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace GithubGists.Selenium.Helpers;

public abstract class HelperBase
{
    protected HelperBase(IWebDriver driver, WebDriverWait wait, IJavaScriptExecutor javaScriptExecutor)
    {
        Driver = driver;
        Wait = wait;
        JavaScriptExecutor = javaScriptExecutor;
    }

    protected readonly IWebDriver Driver;
    protected readonly WebDriverWait Wait;
    protected readonly IJavaScriptExecutor JavaScriptExecutor;
}