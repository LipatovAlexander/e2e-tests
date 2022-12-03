namespace Gist.Github.Tests;

[TestFixture]
public abstract class TestBase
{
    protected readonly ApplicationManager Application = SetUpFixture.Application;
}