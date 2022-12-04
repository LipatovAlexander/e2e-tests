namespace GithubGists.Selenium.Tests;

[TestFixture]
public abstract class TestBase
{
    protected readonly ApplicationManager Application = SetUpFixture.Application;
}