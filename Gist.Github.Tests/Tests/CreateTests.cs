using Gist.Github.Model;

namespace Gist.Github.Tests;

public class CreateTests : TestBase
{
    [Test]
    public void Create()
    {
        // Arrange
        var guid = Guid.NewGuid().ToString();
        var gist = new GistData
        {
            FileName = $"file_{guid}",
            Description = $"description ${guid}",
            Content = $"content {guid}"
        };

        // Act
        Application.Navigation.OpenNewGistPage();
        Application.Gist.CreateGist(gist);
        var actualGist = Application.Gist.GetCreatedGist();

        // Assert
        Assert.AreEqual(gist.Description, actualGist.Description);
        Assert.AreEqual(gist.FileName, actualGist.FileName);
        Assert.AreEqual(gist.Content, actualGist.Content);
    }
}