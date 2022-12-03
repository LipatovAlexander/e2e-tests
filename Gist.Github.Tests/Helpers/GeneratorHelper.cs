using System.Text.Json;
using Gist.Github.Model;

namespace Gist.Github.Helpers;

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