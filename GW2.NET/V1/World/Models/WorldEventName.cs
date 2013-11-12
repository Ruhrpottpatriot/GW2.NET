// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventName.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the EventName type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

using Newtonsoft.Json;

namespace GW2DotNET.V1.World.Models
{
    /// <summary>Represents an event name from he event names api.</summary>
    [JsonObject]
    internal class WorldEventName
    {
        /// <summary>Initializes a new instance of the <see cref="WorldEventName"/> class.</summary>
        /// <param name="id">The id of the event.</param>
        /// <param name="name">The name of the event.</param>
        [JsonConstructor]
        public WorldEventName(Guid id, string name)
        {
            this.Name = name;
            this.Id = id;
        }

        /// <summary>Gets the event id.</summary>
        [JsonProperty("id")]
        public Guid Id
        {
            get;
            private set;
        }

        /// <summary>Gets the event name.</summary>
        [JsonProperty("name")]
        public string Name
        {
            get;
            private set;
        }
    }
}
