using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FestivalInstrumentMapper
{
    public class Settings
    {
        public const string SettingsFilepath = "Settings.json";

        public static void Save(Settings settings) => File.WriteAllText(SettingsFilepath, System.Text.Json.JsonSerializer.Serialize(settings));

        public static Settings Load()
        {
            Settings settings = new();
            if (!File.Exists(SettingsFilepath))
            {
                Save(settings);
                return settings;
            }

            string text = File.ReadAllText(SettingsFilepath);

            if (string.IsNullOrWhiteSpace(text))
            {
                Save(settings);
                return settings;
            }

            settings = JsonSerializer.Deserialize<Settings>(text)!;

            return settings;
        }

        public string Profile { get; set; } = "< default >";
    }
}
