using System.Collections.Generic;
using System.Linq;
using System.Net;

using GW2DotNET.Models;

using Newtonsoft.Json.Linq;

namespace GW2DotNET.Events
{
    public class WorldData
    {
        public IEnumerable<World> GetWorlds(string language = "en")
        {
            var jsonString = new WebClient().DownloadString("https://api.guildwars2.com/v1/world_names.json?lang=" + language);

            var worlds = (JArray)JObject.Parse(jsonString)[""];

            return worlds.Select(world => new World(int.Parse((string)world["id"]), (string)world["name"]));
        }

        public IEnumerable<World> GetMaps(string language = "en")
        {
            var jsonString = new WebClient().DownloadString("https://api.guildwars2.com/v1/map_names.json?lang=" + language);

            var maps = (JArray)JObject.Parse(jsonString)[""];

            return maps.Select(map => new World(int.Parse((string)map["id"]), (string)map["name"]));
        }
    }
}
