// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapNameDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the MapNameDataContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace GW2NET.V1.Maps.Json
{
    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:1/map_names")]
    internal sealed class MapNameDataContract
    {
        [DataMember(Name = "id", Order = 0)]
        internal string Id { get; set; }

        [DataMember(Name = "name", Order = 1)]
        internal string Name { get; set; }
    }
}
