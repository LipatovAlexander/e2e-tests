namespace Gist.Github.Tests;

[TestFixture]
public class AuthTest : TestBase
{
    [Test]
    public void Auth()
    {
        OpenHomePage();
        Login();
        Thread.Sleep(3000);
    }
}