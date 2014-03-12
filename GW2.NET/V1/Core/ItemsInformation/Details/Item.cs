// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Item.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about an in-game item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Core.ItemsInformation.Details
{
    using System;

    using GW2DotNET.V1.Core.ItemsInformation.Details.Items;

    using Newtonsoft.Json;

    /// <summary>
    ///     Represents detailed information about an in-game item.
    /// </summary>
    [JsonConverter(typeof(ItemConverter))]
    public abstract class Item : JsonObject, IEquatable<Item>, IComparable<Item>
    {
        /// <summary>Initializes a new instance of the <see cref="Item"/> class.</summary>
        /// <param name="type">The item's type.</param>
        protected Item(ItemType type)
        {
            this.Type = type;
        }

        /// <summary>
        ///     Gets or sets the item's description.
        /// </summary>
        [JsonProperty("description", Order = 2)]
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the item's additional flags.
        /// </summary>
        [JsonProperty("flags", Order = 10)]
        public ItemFlags Flags { get; set; }

        /// <summary>
        ///     Gets or sets the item's game types.
        /// </summary>
        [JsonProperty("game_types", Order = 9)]
        public GameTypes GameTypes { get; set; }

        /// <summary>
        ///     Gets or sets the item's icon ID for use with the render service.
        /// </summary>
        [JsonProperty("icon_file_id", Order = 7)]
        public int IconFileId { get; set; }

        /// <summary>
        ///     Gets or sets the item's icon signature for use with the render service.
        /// </summary>
        [JsonProperty("icon_file_signature", Order = 8)]
        public string IconFileSignature { get; set; }

        /// <summary>
        ///     Gets or sets the item's ID.
        /// </summary>
        [JsonProperty("item_id", Order = 0)]
        public int ItemId { get; set; }

        /// <summary>
        ///     Gets or sets the item's level.
        /// </summary>
        [JsonProperty("level", Order = 4)]
        public int Level { get; set; }

        /// <summary>
        ///     Gets or sets the item's name.
        /// </summary>
        [JsonProperty("name", Order = 1)]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the item's rarity.
        /// </summary>
        [JsonProperty("rarity", Order = 5)]
        public ItemRarity Rarity { get; set; }

        /// <summary>
        ///     Gets or sets the item's restrictions.
        /// </summary>
        [JsonProperty("restrictions", Order = 11)]
        public ItemRestrictions Restrictions { get; set; }

        /// <summary>
        ///     Gets or sets the item's type.
        /// </summary>
        [JsonProperty("type", Order = 3)]
        public ItemType Type { get; set; }

        /// <summary>
        ///     Gets or sets the item's vendor value.
        /// </summary>
        [JsonProperty("vendor_value", Order = 6)]
        public int VendorValue { get; set; }

        /// <summary>
        ///     Indicates whether an object is equal to another object of the same type.
        /// </summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>
        ///     true if the <paramref name="left" /> parameter is equal to the <paramref name="right" /> parameter; otherwise,
        ///     false.
        /// </returns>
        public static bool operator ==(Item left, Item right)
        {
            return object.Equals(left, right);
        }

        /// <summary>
        ///     Indicates whether an object differs from another object of the same type.
        /// </summary>
        /// <param name="left">The object on the left side.</param>
        /// <param name="right">The object on the right side.</param>
        /// <returns>
        ///     true if the <paramref name="left" /> parameter differs from the <paramref name="right" /> parameter;
        ///     otherwise, false.
        /// </returns>
        public static bool operator !=(Item left, Item right)
        {
            return !object.Equals(left, right);
        }

        /// <summary>Compares the current object with another object of the same type.</summary>
        /// <returns>A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>. </returns>
        /// <param name="other">An object to compare with this object.</param>
        public int CompareTo(Item other)
        {
            if (other == null)
            {
                return 1;
            }

            return this.ItemId.CompareTo(other.ItemId);
        }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(Item other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }

            if (object.ReferenceEquals(this, other))
            {
                return true;
            }

            return this.ItemId == other.ItemId;
        }

        /// <summary>Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.</summary>
        /// <returns>true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.</returns>
        /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>. </param>
        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(null, obj))
            {
                return false;
            }

            if (object.ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((Item)obj);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. 
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return this.ItemId;
        }
    }
}