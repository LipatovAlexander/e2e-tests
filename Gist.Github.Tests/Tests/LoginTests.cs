using Gist.Github.Model;

namespace Gist.Github.Tests;

public class LoginTests : TestBase
{
    [Test]
    public void LoginWithValidData()
    {
        var user = new AccountData
        {
            Username = Settings.Username,
            Password = Settings.Password
        };
        TestLogin(user, true);
    }

    [Test]
    public void LoginWithInvalidData()
    {
        var user = new AccountData
        {
            Username = "invalid",
            Password = "invalid"
        };
        TestLogin(user, false);
    }

    private void TestLogin(AccountData user, bool isValid)
    {
        // Arrange
        Application.Auth.Logout();

        // Act
        Application.Auth.Login(user);

        // Assert
        var isLoggedIn = Application.Auth.IsLoggedIn(user.Username);
        Assert.AreEqual(isValid, isLoggedIn);
    }
}