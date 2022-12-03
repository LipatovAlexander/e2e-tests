using Gist.Github.Model;

namespace Gist.Github.Tests;

public class CreateTests : TestBase
{
    [Test]
    public void Create()
    {
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