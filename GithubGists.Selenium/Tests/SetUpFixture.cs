namespace GithubGists.Selenium.Tests;

[SetUpFixture]
public sealed class SetUpFixture
{
    public static ApplicationManager Application = null!;

    [OneTimeSetUp]
    public void SetUp()
    {
        Application = ApplicationManager.GetInstance();
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        Application.Dispose();
    }
}