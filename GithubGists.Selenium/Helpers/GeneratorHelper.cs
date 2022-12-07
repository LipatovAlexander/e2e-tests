using System.Text.Json;
using GithubGists.Selenium.Model;

namespace GithubGists.Selenium.Helpers;

public sealed class GeneratorHelper
{
    private const string FilePath =
        "C:\\Users\\pc\\source\\repos\\Tests\\GistGenerator\\bin\\Debug\\net7.0\\gists.json";

    public static IReadOnlyCollection<GistData> ReadGeneratedGists()
    {
        var json = File.ReadAllText(FilePath);

        return JsonSerializer.Deserialize<GistData[]>(json)!;
    }
}