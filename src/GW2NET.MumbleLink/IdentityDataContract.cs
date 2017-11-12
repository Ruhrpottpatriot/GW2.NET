// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IdentityDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the IdentityDataContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.MumbleLink
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
    [DataContract]
    internal sealed class IdentityDataContract
    {
        [DataMember(Name = "commander", Order = 5)]
        internal bool Commander { get; set; }

        [DataMember(Name = "map_id", Order = 2)]
        internal int MapId { get; set; }

        [DataMember(Name = "name", Order = 0)]
        internal string Name { get; set; }

        [DataMember(Name = "profession", Order = 1)]
        internal int Profession { get; set; }

        [DataMember(Name = "race", Order = 7)]
        internal int Race { get; set; }

        [DataMember(Name = "team_color_id", Order = 4)]
        internal int TeamColorId { get; set; }

        [DataMember(Name = "world_id", Order = 3)]
        internal long WorldId { get; set; }

        [DataMember(Name = "fov", Order = 6)]
        internal double FieldOfView { get; set; }
    }
}