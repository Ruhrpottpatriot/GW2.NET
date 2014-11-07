// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapBonusDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the MapBonusDataContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.WorldVersusWorld.Matches.Json
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:1/wvw/match_details")]
    internal sealed class MapBonusDataContract
    {
        [DataMember(Name = "type", Order = 0)]
        internal string Type { get; set; }

        [DataMember(Name = "owner", Order = 1)]
        internal string Owner { get; set; }
    }
}