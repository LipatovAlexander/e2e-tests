namespace Gist.Github.Tests.Model;

public sealed class GistData
{
    public required string FileName { get; init; }
    public required string Content { get; init; }
    public string? Description { get; set; }
}