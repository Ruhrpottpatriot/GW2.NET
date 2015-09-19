// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IdentityDTO.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the IdentityDTO type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.MumbleLink
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
    [DataContract]
    public sealed class IdentityDTO
    {
        [DataMember(Name = "commander", Order = 5)]
        public bool Commander { get; set; }

        [DataMember(Name = "map_id", Order = 2)]
        public int MapId { get; set; }

        [DataMember(Name = "name", Order = 0)]
        public string Name { get; set; }

        [DataMember(Name = "profession", Order = 1)]
        public int Profession { get; set; }

        [DataMember(Name = "race", Order = 7)]
        public int Race { get; set; }

        [DataMember(Name = "team_color_id", Order = 4)]
        public int TeamColorId { get; set; }

        [DataMember(Name = "world_id", Order = 3)]
        public long WorldId { get; set; }

        [DataMember(Name = "fov", Order = 6)]
        public double FieldOfView { get; set; }
    }
}