using GithubGists.Selenium.Model;

namespace GithubGists.Selenium.Tests;

public abstract class AuthBase : TestBase
{
    [SetUp]
    public void SetUp()
    {
        var user = new AccountData
        {
            Username = Settings.Username,
            Password = Settings.Password
        };

        Application.Auth.Login(user);
    }
}