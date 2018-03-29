// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkinDTO.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.Json
{
    using System.Runtime.Serialization;

    [DataContract]
    public sealed class SkinDTO
    {
        [DataMember(Name = "name", Order = 0)]
        public string Name { get; set; }

        [DataMember(Name = "type", Order = 1)]
        public string Type { get; set; }

        [DataMember(Name = "flags", Order = 2)]
        public string[] Flags { get; set; }

        [DataMember(Name = "restrictions", Order = 3)]
        public string[] Restrictions { get; set; }

        [DataMember(Name = "id", Order = 4)]
        public int Id { get; set; }

        [DataMember(Name = "icon", Order = 5)]
        public string IconUrl { get; set; }

        [DataMember(Name = "description", Order = 6)]
        public string Description { get; set; }

        [DataMember(Name = "details", Order = 7)]
        public DetailsDTO Details { get; set; }
    }
}