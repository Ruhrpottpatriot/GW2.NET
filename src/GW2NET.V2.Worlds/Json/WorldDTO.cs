// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WorldDTO.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the WorldDTO type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Worlds.Json
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented",
        Justification = "http://wiki.guildwars2.com/wiki/API:2/worlds")]
    public sealed class WorldDTO
    {
        [DataMember(Order = 0, Name = "id")]
        public int Id { get; set; }

        [DataMember(Order = 1, Name = "name")]
        public string Name { get; set; }
    }
}