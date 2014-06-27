// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapBonus.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a World versus World map's bonus.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.WorldVersusWorld.Matches.Contracts.Maps.Bonuses
{
    using System.Runtime.Serialization;

    using GW2DotNET.Common.Contracts;
    using GW2DotNET.V1.WorldVersusWorld.Matches.Contracts.Common;

    /// <summary>Represents a World versus World map's bonus.</summary>
    public class MapBonus : ServiceContract
    {
        /// <summary>Gets or sets the team that holds the bonus.</summary>
        [DataMember(Name = "owner")]
        public TeamColor Owner { get; set; }

        /// <summary>Gets or sets the bonus type.</summary>
        [DataMember(Name = "type")]
        public MapBonusType Type { get; set; }
    }
}