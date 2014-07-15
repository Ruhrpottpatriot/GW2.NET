// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapBonus.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the base class for World versus World map bonuses.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.WorldVersusWorld.Contracts.Maps.Bonuses
{
    using System.Runtime.Serialization;

    using GW2DotNET.Common.Contracts;
    using GW2DotNET.V1.WorldVersusWorld.Contracts.Common;

    /// <summary>Provides the base class for World versus World map bonuses.</summary>
    public class MapBonus : ServiceContract
    {
        /// <summary>Gets or sets the team that holds the bonus.</summary>
        [DataMember(Name = "owner")]
        public virtual TeamColor Owner { get; set; }
    }
}