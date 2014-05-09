// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkinnedItem.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the base class for types that represent a skinned item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Common
{
    using System.Runtime.Serialization;

    /// <summary>Provides the base class for types that represent a skinned item.</summary>
    public abstract class SkinnedItem : Item
    {
        /// <summary>Initializes a new instance of the <see cref="SkinnedItem"/> class.</summary>
        /// <param name="type">The item's type.</param>
        protected SkinnedItem(ItemType type)
            : base(type)
        {
        }

        /// <summary>Gets or sets the item's default skin identifier.</summary>
        [DataMember(Name = "default_skin", Order = 100)]
        public virtual int DefaultSkin { get; set; }
    }
}