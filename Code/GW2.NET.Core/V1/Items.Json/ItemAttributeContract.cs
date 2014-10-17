// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemAttributeContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents an item attribute.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Items.Json
{
    using System.Runtime.Serialization;

    /// <summary>Represents an item attribute.</summary>
    [DataContract]
    public sealed class ItemAttributeContract
    {
        /// <summary>Gets or sets the attribute's type.</summary>
        [DataMember(Name = "attribute", Order = 0)]
        public string Attribute { get; set; }

        /// <summary>Gets or sets the attribute's modifier.</summary>
        [DataMember(Name = "modifier", Order = 1)]
        public string Modifier { get; set; }
    }
}