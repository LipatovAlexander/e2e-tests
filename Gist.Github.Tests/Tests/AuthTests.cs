using Gist.Github.Model;

namespace Gist.Github.Tests;

public class AuthTests : TestBase
{
    [Test]
    public void Auth()
    {
        // Arrange
        var user = new AccountData
        {
            Username = "githubtests-itis",
            Password = "g1thubTests"
        };

        // Act
        Application.Auth.Login(user);

        // Assert
        var actualUsername = Application.Auth.GetUsername();
        Assert.AreEqual(user.Username, actualUsername);
    }
}