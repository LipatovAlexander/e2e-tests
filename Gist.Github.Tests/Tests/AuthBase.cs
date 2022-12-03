using Gist.Github.Model;

namespace Gist.Github.Tests;

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