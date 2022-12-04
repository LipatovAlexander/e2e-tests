using System.Text.Json;

namespace GithubGists.Selenium;

public static class Settings
{
    private const string FilePath = "Settings.json";

    public static string BaseUrl => Model.BaseUrl;
    public static string Username => Model.Username;
    public static string Password => Model.Password;
    
    static Settings()
    {
        if (!File.Exists(FilePath))
        {
            throw new Exception("Problem: settings file not found: " + FilePath);
        }

        var json = File.ReadAllText(FilePath);
        Model = JsonSerializer.Deserialize<SettingsModel>(json)!;
    }

    private static readonly SettingsModel Model;
}

internal class SettingsModel
{
    public required string BaseUrl { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
}