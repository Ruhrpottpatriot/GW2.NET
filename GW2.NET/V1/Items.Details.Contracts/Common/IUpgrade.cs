// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUpgrade.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the interface for items that provide a bonus when equipped.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.Common
{
    using System.Runtime.Serialization;

    /// <summary>Provides the interface for items that provide a bonus when equipped.</summary>
    public interface IUpgrade
    {
        /// <summary>Gets or sets the item's attributes.</summary>
        [DataMember(Name = "attributes")]
        ItemAttributeCollection Attributes { get; set; }

        /// <summary>Gets or sets the item's buff.</summary>
        [DataMember(Name = "buff")]
        ItemBuff Buff { get; set; }
    }
}