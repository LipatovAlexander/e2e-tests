namespace Gist.Github.Tests;

public class AuthTests : TestBase
{
    [Test]
    public void Auth()
    {
        var user = new AccountData
        {
            Username = "githubtests-itis",
            Password = "g1thubTests"
        };
        
        OpenHomePage();
        Login(user);
    }
}