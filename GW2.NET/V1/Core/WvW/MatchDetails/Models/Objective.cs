// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Objective.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.WvW.MatchDetails.Models
{
    /// <summary>
    /// Represents one of a World versus World map's objectives.
    /// </summary>
    public class Objective
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Objective"/> class.
        /// </summary>
        public Objective()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Objective"/> class using the specified values.
        /// </summary>
        /// <param name="id">The objective's ID.</param>
        /// <param name="owner">The objective's owner.</param>
        /// <param name="ownerGuild">The guild ID of the guild currently claiming the objective.</param>
        public Objective(int id, TeamColor owner, Guid? ownerGuild = null)
        {
            this.Id = id;
            this.Owner = owner;
            this.OwnerGuild = ownerGuild;
        }

        /// <summary>
        /// Gets or sets the objective's ID.
        /// </summary>
        [JsonProperty("id", Order = 0)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the objective's owner.
        /// </summary>
        [JsonProperty("owner", Order = 1)]
        public TeamColor Owner { get; set; }

        /// <summary>
        /// Gets or sets the guild ID of the guild currently claiming the objective.
        /// </summary>
        [JsonProperty("owner_guild", Order = 2, NullValueHandling = NullValueHandling.Ignore)]
        public Guid? OwnerGuild { get; set; }

        /// <summary>
        /// Gets the JSON representation of this instance.
        /// </summary>
        /// <returns>Returns a JSON <see cref="System.String"/>.</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        /// <summary>
        /// Gets the JSON representation of this instance.
        /// </summary>
        /// <param name="indent">A value that indicates whether to indent the output.</param>
        /// <returns>Returns a JSON <see cref="System.String"/>.</returns>
        public string ToString(bool indent)
        {
            return JsonConvert.SerializeObject(this, indent ? Formatting.Indented : Formatting.None);
        }
    }
}