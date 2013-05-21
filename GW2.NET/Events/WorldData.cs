using System.Collections.Generic;
using System.IO;
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
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.guildwars2.com/v1/world_names.json?lang=" + language);

            request.Method = WebRequestMethods.Http.Get;
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Accept = "application/json";

            string jsonString;

            using (var response = request.GetResponse())
            {
                using (var sr = new StreamReader(response.GetResponseStream()))
                {
                    jsonString = sr.ReadToEnd().Insert(0, "{\"worlds\":");

                    jsonString = jsonString.Insert(jsonString.Length, "}");
                }
            }

            var worlds = (JArray)JObject.Parse(jsonString)["worlds"];

            return worlds.Select(world => new World(int.Parse((string)world["id"]), (string)world["name"]));
        }

        public IEnumerable<World> GetMaps(string language = "en")
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.guildwars2.com/v1/world_names.json?lang=" + language);

            request.Method = WebRequestMethods.Http.Get;
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Accept = "application/json";

            string jsonString;

            using (var response = request.GetResponse())
            {
                using (var sr = new StreamReader(response.GetResponseStream()))
                {
                    jsonString = sr.ReadToEnd().Insert(0, "{\"maps\":");

                    jsonString = jsonString.Insert(jsonString.Length, "}");
                }
            }
            var maps = (JArray)JObject.Parse(jsonString)["maps"];

            return maps.Select(map => new World(int.Parse((string)map["id"]), (string)map["name"]));
        }
    }
}