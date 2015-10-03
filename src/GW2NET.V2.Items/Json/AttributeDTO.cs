// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AttributeDTO.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the AttributeDTO type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Items.Json
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:2/items")]
    public sealed class AttributeDTO
    {
        [DataMember(Name = "attribute", Order = 0)]
        public string Attribute { get; set; }

        [DataMember(Name = "modifier", Order = 1)]
        public int Modifier { get; set; }
    }
}