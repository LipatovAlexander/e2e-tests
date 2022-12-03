using CommandLine;

namespace GistGenerator;

public sealed class Options
{
    [Option('c', "count", Default = 1, Required = false)]
    public int Count { get; set; }

    [Option('p', "path", Default = "gists.json", Required = false)]
    public string FilePath { get; set; } = default!;
}