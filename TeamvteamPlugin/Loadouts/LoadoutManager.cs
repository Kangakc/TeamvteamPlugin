using Newtonsoft.Json;
using Rocket.Core.Logging;
using Rocket.Unturned.Chat;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamvteamPlugin.Loadouts;

public class LoadoutManager
{
    public static List<Loadout> loadouts = new List<Loadout>();

    public static void read()
    {
        if (!File.Exists($@"Plugins\TeamvteamPlugin\loudouts.json"))
        {
            Logger.Log("file not found");
            return;
        }
        using StreamReader r = File.OpenText($@"Plugins\TeamvteamPlugin\loudouts.json");
        string json = r.ReadToEnd();

        loadouts = JsonConvert.DeserializeObject<List<Loadout>>(json);
    }
    public static void write() 
    {
        using StreamWriter file = File.CreateText($@"Plugins\TeamvteamPlugin\loudouts.json");
        using JsonWriter writer = new JsonTextWriter(file);
        JsonSerializer serializer = new JsonSerializer();
        serializer.Formatting = Formatting.Indented;
        serializer.Serialize(writer, loadouts);
    }
}
