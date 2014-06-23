// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Backpack.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a backpack.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Backpacks
{
    using System.Runtime.Serialization;

    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Common;

    /// <summary>Represents a backpack.</summary>
    public class Backpack : CombatItem, ISkinnable
    {
        /// <summary>Initializes a new instance of the <see cref="Backpack" /> class.</summary>
        public Backpack()
            : base(ItemType.Back)
        {
        }

        /// <summary>Gets or sets the item's default skin identifier.</summary>
        [DataMember(Name = "default_skin")]
        public virtual int DefaultSkin { get; set; }

        /// <summary>Gets the name of the property that provides additional information.</summary>
        /// <returns>The name of the property.</returns>
        protected override string GetTypeKey()
        {
            return "back";
        }
    }
}