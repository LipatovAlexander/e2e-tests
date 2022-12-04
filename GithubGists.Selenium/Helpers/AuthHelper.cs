using GithubGists.Selenium.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace GithubGists.Selenium.Helpers;

public sealed class AuthHelper : HelperBase
{
    public AuthHelper(IWebDriver driver, WebDriverWait wait, IJavaScriptExecutor javaScriptExecutor, NavigationHelper navigation)
        : base(driver, wait, javaScriptExecutor)
    {
        _navigation = navigation;
    }

    public void Login(AccountData user)
    {
        if (IsLoggedIn())
        {
            if (IsLoggedIn(user.Username))
            {
                return;
            }

            Logout();
        }
    
        _navigation.OpenHomePage();

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

    public void Logout()
    {
        if (!IsLoggedIn())
        {
            return;
        }
    
        Driver.FindElement(By.CssSelector(".name > .avatar")).Click();
        Driver.FindElement(By.CssSelector(".dropdown-signout")).Click();
        Driver.FindElement(By.CssSelector(".btn")).Click();
    }

    public bool IsLoggedIn()
    {
        return !string.IsNullOrEmpty(GetUsername());
    }

    public bool IsLoggedIn(string username)
    {
        return GetUsername() == username;
    }

    private string GetUsername()
    {
        return Driver
            .FindElement(By.CssSelector("meta[name=\"user-login\"]"))
            .GetAttribute("content");
    }

    private readonly NavigationHelper _navigation;
}