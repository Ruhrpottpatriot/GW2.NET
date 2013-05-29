using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GW2DotNET.V1.WvW.Models
{
    class WvWMatchDetails
    {
        /// <summary>   
        /// Map types   
        /// </summary>   
        public enum MapType
        {
            /// <summary>   
            /// Red team borderlands   
            /// </summary>   
            RedHome,

            /// <summary>   
            /// Green team borderlands   
            /// </summary>   
            GreenHome,

            /// <summary>   
            /// Blue team borderlands   
            /// </summary>   
            BlueHome,

            /// <summary>   
            /// Eternal Battlegrounds   
            /// </summary>   
            Center
        }

        /// <summary>   
        /// Gets or sets the match ID, which is a string such as "1-2".   
        /// The first number is 1 for NA or 2 for EU. The second number   
        /// is the tier.   
        /// </summary>   
        [JsonProperty("match_id")]
        public string MatchId { get; set; }

        /// <summary>   
        /// Gets or sets a List containing the overall scores for the   
        /// match. The team is determined by the position in the List.   
        /// Element 0: Red Team   
        /// Element 1: Green Team   
        /// Element 2: Blue Team   
        /// We might want to consider hiding this for deserialization use only,   
        /// and exposing something friendlier to the caller.   
        /// </summary>   
        [JsonProperty("scores")]
        public List<int> Scores { get; set; }

        /// <summary>   
        /// Gets or sets a List containing the map details for the four   
        /// maps in a WVW match.   
        /// </summary>   
        [JsonProperty("maps")]
        public List<MatchMap> Maps { get; set; }

        /// <summary>   
        /// Represents the details for a map in a WVW match.   
        /// </summary>   
        public class MatchMap
        {
            /// <summary>   
            /// Gets or sets the map type (RedHome, GreenHome, BlueHome, or Center)   
            /// </summary>   
            [JsonProperty("type")]
            public MapType Type { get; set; }

            /// <summary>   
            /// Gets or sets a List containing the scores for that particular map.   
            /// The team is determined by the position in the List.   
            /// Element 0: Red Team   
            /// Element 1: Green Team   
            /// Element 2: Blue Team   
            /// We might want to consider hiding this for deserialization use only,   
            /// and exposing something friendlier to the caller.   
            /// </summary>   
            [JsonProperty("scores")]
            public List<int> Scores { get; set; }

            /// <summary>   
            /// Gets or sets a List of objectives for this map.   
            /// </summary>   
            [JsonProperty("objectives")]
            public List<Objective> Objectives { get; set; }

            /// <summary>   
            /// Represents an objective in a WVW map.   
            /// </summary>   
            public class Objective
            {
                /// <summary>   
                /// Owning team colors   
                /// </summary>   
                public enum OwnerColor
                {
                    /// <summary>   
                    /// Red team   
                    /// </summary>   
                    Red,

                    /// <summary>   
                    /// Green team   
                    /// </summary>   
                    Green,

                    /// <summary>   
                    /// Blue team   
                    /// </summary>   
                    Blue
                }

                /// <summary>   
                /// Gets or sets the id of the objective.   
                /// For now, in order to resolve this to a name and other useful   
                /// information, we'll have to use a hard-coded list. The   
                /// objective_names.json call is very broken. See   
                /// https://forum-en.guildwars2.com/forum/community/api/WvW-objective-names/   
                /// </summary>   
                [JsonProperty("id")]
                public int Id { get; set; }

                /// <summary>   
                /// Gets or sets the owning team of the objective   
                /// </summary>   
                [JsonProperty("owner")]
                public OwnerColor OwningTeamColor { get; set; }

                /// <summary>   
                /// Gets or sets the owning guild ID. Note that this   
                /// is null-able because objectives do not always have owning guilds.   
                /// </summary>   
                [JsonProperty("owner_guild")]
                public Guid? OwningGuildId { get; set; }
            }
        }
    }
}
