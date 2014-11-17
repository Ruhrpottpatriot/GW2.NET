// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RenownTaskDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the RenownTaskDataContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Floors
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:1/map_floor")]
    internal sealed class RenownTaskDataContract
    {
        [DataMember(Name = "task_id", Order = 0)]
        internal int TaskId { get; set; }

        [DataMember(Name = "objective", Order = 1)]
        internal string Objective { get; set; }

        [DataMember(Name = "level", Order = 2)]
        internal int Level { get; set; }

        [DataMember(Name = "coord", Order = 3)]
        internal double[] Coordinates { get; set; }
    }
}