// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapBonusDTO.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the MapBonusDTO type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.WorldVersusWorld.Matches.Json
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract]
    public sealed class MapBonusDTO
    {
        /// <summary>Map bonus type</summary>
        [DataMember(Name = "type", Order = 0)]
        public string Type { get; set; }

        /// <summary>Map bonus owner</summary>
        [DataMember(Name = "owner", Order = 1)]
        public string Owner { get; set; }
    }
}