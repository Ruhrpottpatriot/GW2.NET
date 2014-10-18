// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompetitiveMapContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the CompetitiveMapContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.WorldVersusWorld.Json
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
    internal sealed class CompetitiveMapContract
    {
        [DataMember(Name = "bonuses", Order = 3)]
        internal ICollection<MapBonusContract> Bonuses { get; set; }

        [DataMember(Name = "objectives", Order = 2)]
        internal ICollection<ObjectiveContract> Objectives { get; set; }

        [DataMember(Name = "scores", Order = 1)]
        internal int[] Scores { get; set; }

        [DataMember(Name = "type", Order = 0)]
        internal string Type { get; set; }
    }
}