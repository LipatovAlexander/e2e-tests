namespace Gist.Github.Tests;

public sealed class Gist
{
    public required string FileName { get; init; }
    public required string Content { get; init; }
    public string? Description { get; set; }
}