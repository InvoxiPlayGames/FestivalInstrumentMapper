using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FestivalInstrumentMapper
{
    internal class LegendaryUninstallerManifest
    {
        [JsonPropertyName("args")]
        public string? Args { get; set; }
        [JsonPropertyName("path")]
        public string? Path { get; set; }
    }

    internal class LegendaryManifest
    {
        [JsonPropertyName("app_name")]
        public string? AppName { get; set; }
        [JsonPropertyName("base_urls")]
        public string[]? BaseURLs { get; set; }
        [JsonPropertyName("can_run_offline")]
        public bool CanRunOffline { get; set; }
        [JsonPropertyName("egl_guid")]
        public string? EGLGUID { get; set; }
        [JsonPropertyName("executable")]
        public string? Executable { get; set; }
        [JsonPropertyName("install_path")]
        public string? InstallPath { get; set; }
        [JsonPropertyName("install_size")]
        public long InstallSize { get; set; }
        [JsonPropertyName("install_tags")]
        public string[]? InstallTags { get; set; }
        [JsonPropertyName("is_dlc")]
        public bool IsDLC { get; set; }
        [JsonPropertyName("launch_parameters")]
        public string? LaunchParameters { get; set; }
        [JsonPropertyName("manifest_path")]
        public string? ManifestPath { get; set; }
        [JsonPropertyName("needs_verification")]
        public bool NeedsVerification { get; set; }
        [JsonPropertyName("platform")]
        public string? Platform { get; set; }
        [JsonPropertyName("prereq_info")]
        public string? PrereqInfo { get; set; }
        [JsonPropertyName("requires_ot")]
        public bool RequiresOT { get; set; }
        [JsonPropertyName("save_path")]
        public string? SavePath { get; set; }
        [JsonPropertyName("title")]
        public string? Title { get; set; }
        [JsonPropertyName("uninstaller")]
        public LegendaryUninstallerManifest? Uninstaller { get; set; }
        [JsonPropertyName("version")]
        public string? Version { get; set; }
    }

    internal class HeroicLauncherDetection
    {
        public static string? GetInstallDirectory(string appName)
        {
            string heroicInstallData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                "/heroic/legendaryConfig/legendary/installed.json";
            var heroicGames = new Dictionary<string, LegendaryManifest>();

            try
            {
                heroicGames = JsonSerializer.Deserialize<Dictionary<string, LegendaryManifest>>(File.ReadAllText(heroicInstallData));
            }
            catch
            {
                return null;
            }

            if (heroicGames == null || heroicGames?.Count == 0)
                return null;

            var gameInstall = heroicGames?.FirstOrDefault(x => x.Key.Equals(appName, StringComparison.OrdinalIgnoreCase));

            if (Directory.Exists(gameInstall?.Value.InstallPath))
                return gameInstall?.Value.InstallPath;
            else
                return null;
        }
    }
}
