using System.Text.Json;
using System.Text.Json.Serialization;

namespace GistGenerator;

public sealed class Generator
{
    private readonly Randomizer _randomizer = new(Random.Shared);

    private const double DescriptionProbability = 0.5;
    
    private static readonly JsonSerializerOptions SerializerOptions = new()
    {
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    public void Generate(Options options)
    {
        var gists = new List<GistData>(options.Count);

        for (var i = 0; i < options.Count; i++)
        {
            var gist = new GistData
            {
                FileName = _randomizer.GetString(15),
                Content = _randomizer.GetSentence(20)
            };

            if (_randomizer.TryProbability(DescriptionProbability))
            {
                gist.Description = _randomizer.GetSentence(5);
            }
            
            gists.Add(gist);
        }
        
        File.WriteAllText(options.FilePath, JsonSerializer.Serialize(gists, SerializerOptions));
    }
}