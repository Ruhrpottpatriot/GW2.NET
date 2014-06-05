// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapBonus.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a World versus World map's bonus.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.WorldVersusWorld.Matches.Details.Contracts.Maps.Bonuses
{
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Common.Contracts;
    using GW2DotNET.V1.WorldVersusWorld.Matches.Details.Contracts.Common;

    /// <summary>Represents a World versus World map's bonus.</summary>
    public class MapBonus : JsonObject
    {
        /// <summary>Gets or sets the team that holds the bonus.</summary>
        [DataMember(Name = "owner", Order = 1)]
        public TeamColor Owner { get; set; }

        /// <summary>Gets or sets the bonus type.</summary>
        [DataMember(Name = "type", Order = 0)]
        public MapBonusType Type { get; set; }
    }
}