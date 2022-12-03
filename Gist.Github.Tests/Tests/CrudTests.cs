using Gist.Github.Model;

namespace Gist.Github.Tests;

public class CrudTests : TestBase
{
    private string _username = null!;
    private GistData _gist = null!; 

    [OneTimeSetUp]
    public void SetUp()
    {
        _username = Application.Auth.GetUsername()
            ?? throw new InvalidOperationException();
            
        var guid = Guid.NewGuid().ToString();
        _gist = new GistData
        {
            FileName = $"file_{guid}",
            Description = $"description ${guid}",
            Content = $"content {guid}"
        };
    }

    [Test]
    public void Create()
    {
        // Arrange

        // Act
        Application.Gist.CreateGist(_gist);
        var actualGist = Application.Gist.GetGist(_username, _gist.Id)!;

        // Assert
        Assert.NotNull(actualGist);
        Assert.AreEqual(_gist.Description, actualGist.Description);
        Assert.AreEqual(_gist.FileName, actualGist.FileName);
        Assert.AreEqual(_gist.Content, actualGist.Content);
    }

    [Test]
    public void Delete()
    {
        // Arrange

        // Act
        Application.Gist.DeleteGist(_username, _gist.Id);

        // Assert
        var deletedGist = Application.Gist.GetGist(_username, _gist.Id);
        Assert.Null(deletedGist);
    }
}