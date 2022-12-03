namespace Gist.Github.Model;

public sealed class GistData
{
    public string Id { get; set; } = null!;
    public required string FileName { get; init; }
    public required string Content { get; init; }
    public string? Description { get; set; }
}