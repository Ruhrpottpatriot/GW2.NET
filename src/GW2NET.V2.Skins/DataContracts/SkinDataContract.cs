// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkinDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the skin data contract.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Skins
{
    using System.Runtime.Serialization;

    /// <summary>Defines the skin data contract.</summary>
    [DataContract]
    internal sealed class SkinDataContract
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [DataMember(Name = "name", Order = 0)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        [DataMember(Name = "type", Order = 1)]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the flags.
        /// </summary>
        [DataMember(Name = "flags", Order = 2)]
        public string[] Flags { get; set; }

        /// <summary>
        /// Gets or sets the restrictions.
        /// </summary>
        [DataMember(Name = "restrictions", Order = 3)]
        public string[] Restrictions { get; set; }

        /// <summary>Gets or sets the id.</summary>
        [DataMember(Name = "id", Order = 4)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the icon url.
        /// </summary>
        [DataMember(Name = "icon", Order = 5)]
        public string IconUrl { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [DataMember(Name = "description", Order = 6)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the details.
        /// </summary>
        [DataMember(Name = "details", Order = 7)]
        public DetailsDataContract Details { get; set; }
    }
}