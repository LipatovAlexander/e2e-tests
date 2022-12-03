using Gist.Github.Tests.Model;

namespace Gist.Github.Tests.Tests;

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

        Application.Navigation.OpenHomePage();
        Application.Auth.Login(user);

        var guid = Guid.NewGuid().ToString();
        var gist = new GistData
        {
            FileName = $"file_{guid}",
            Description = $"description ${guid}",
            Content = $"content {guid}"
        };
        Application.Navigation.OpenNewGistPage();
        Application.Gist.CreateGist(gist);
    }
}