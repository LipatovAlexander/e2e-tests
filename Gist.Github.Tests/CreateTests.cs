namespace Gist.Github.Tests;

public class CreateTests : TestBase
{
    [Test]
    public void Create()
    {
        var user = new AccountData
        {
            Username = "githubtests-itis",
            Password = "g1thubTests"
        };

        OpenHomePage();
        Login(user);

        var guid = Guid.NewGuid().ToString();
        var gist = new Gist
        {
            FileName = $"file_{guid}",
            Description = $"description ${guid}",
            Content = $"content {guid}"
        };
        OpenNewGistPage();
        CreateGist(gist);
    }
}