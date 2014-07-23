// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapBonusContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a World versus World map bonus.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.WorldVersusWorld.Contracts
{
    using System.Runtime.Serialization;

    using GW2DotNET.Common.Contracts;

    /// <summary>Represents a World versus World map bonus.</summary>
    public sealed class MapBonusContract : ServiceContract
    {
        /// <summary>Gets or sets the team that holds the bonus.</summary>
        [DataMember(Name = "owner", Order = 1)]
        public string Owner { get; set; }

        /// <summary>Gets or sets the bonus type.</summary>
        [DataMember(Name = "type", Order = 0)]
        public string Type { get; set; }
    }
}