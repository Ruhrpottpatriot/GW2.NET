// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Objective.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents one of a World versus World map's objectives.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.WorldVersusWorldInformation.Details
{
    using System;

    using Newtonsoft.Json;

    /// <summary>
    ///     Represents one of a World versus World map's objectives.
    /// </summary>
    public class Objective : JsonObject
    {
        /// <summary>
        ///     Gets or sets the objective's ID.
        /// </summary>
        [JsonProperty("ID", Order = 0)]
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the objective's owner.
        /// </summary>
        [JsonProperty("owner", Order = 1)]
        public TeamColor Owner { get; set; }

        /// <summary>
        ///     Gets or sets the guild ID of the guild currently claiming the objective.
        /// </summary>
        [JsonProperty("owner_guild", Order = 2, NullValueHandling = NullValueHandling.Ignore)]
        public Guid? OwnerGuild { get; set; }
    }
}