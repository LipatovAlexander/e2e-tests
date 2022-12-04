using GithubGists.Selenium.Helpers;
using GithubGists.Selenium.Model;

namespace GithubGists.Selenium.Tests;

public class CrudTests : AuthBase
{
    public static readonly IReadOnlyCollection<GistData> Gists = GeneratorHelper.ReadGeneratedGists();
    
    [Test, TestCaseSource(nameof(Gists))]
    public void Create(GistData gist)
    {
        // Arrange

        // Act
        Application.Gist.CreateGist(gist);
        var actualGist = Application.Gist.GetGist(Settings.Username, gist.Id)!;

        // Assert
        Assert.NotNull(actualGist);
        Assert.AreEqual(gist.Description, actualGist.Description);
        Assert.AreEqual(gist.FileName, actualGist.FileName);
        Assert.AreEqual(gist.Content, actualGist.Content);
    }

    [Test, TestCaseSource(nameof(Gists))]
    public void Delete(GistData gist)
    {
        // Arrange

        // Act
        Application.Gist.DeleteGist(Settings.Username, gist.Id);

        // Assert
        var deletedGist = Application.Gist.GetGist(Settings.Username, gist.Id);
        Assert.Null(deletedGist);
    }
}