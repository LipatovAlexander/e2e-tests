using Gist.Github.Tests.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Gist.Github.Tests.Helpers;

public sealed class AuthHelper : HelperBase
{
    public AuthHelper(IWebDriver driver, WebDriverWait wait, IJavaScriptExecutor javaScriptExecutor) : base(driver, wait, javaScriptExecutor)
    {
    }

    public void Login(AccountData user)
    {
        Driver
            .FindElement(By.LinkText("Sign in"))
            .Click();
        Wait
            .Until(d => d.FindElement(By.Id("login_field")))
            .SendKeys(user.Username);
        Driver
            .FindElement(By.Id("password"))
            .SendKeys(user.Password);
        Driver
            .FindElement(By.Name("commit"))
            .Click();
    }
}