using Gist.Github.Helpers;
using Gist.Github.Model;

namespace Gist.Github.Tests;

public class CrudTests : TestBase
{
    private string _username = null!;
    public static readonly IReadOnlyCollection<GistData> Gists = GeneratorHelper.ReadGeneratedGists();

    [OneTimeSetUp]
    public void SetUp()
    {
        _username = Application.Auth.GetUsername()
            ?? throw new InvalidOperationException();
    }

    [Test, TestCaseSource(nameof(Gists))]
    public void Create(GistData gist)
    {
        // Arrange

        // Act
        Application.Gist.CreateGist(gist);
        var actualGist = Application.Gist.GetGist(_username, gist.Id)!;

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
        Application.Gist.DeleteGist(_username, gist.Id);

        // Assert
        var deletedGist = Application.Gist.GetGist(_username, gist.Id);
        Assert.Null(deletedGist);
    }
}