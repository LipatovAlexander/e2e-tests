namespace Gist.Github.Tests.Tests;

[TestFixture]
public abstract class TestBase
{
    protected ApplicationManager Application = null!;

    [SetUp]
    public void SetUp()
    {
        Application = new ApplicationManager();
    }
    
    [TearDown]
    protected void TearDown()
    {
        Application.Stop();
    }
}