// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemDetailsResponseConverter.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using GW2DotNET.V1.Core.ItemDetails.Models.ArmorPieces;
using GW2DotNET.V1.Core.ItemDetails.Models.BackPieces;
using GW2DotNET.V1.Core.ItemDetails.Models.Bags;
using GW2DotNET.V1.Core.ItemDetails.Models.Common;
using GW2DotNET.V1.Core.ItemDetails.Models.Consumables;
using GW2DotNET.V1.Core.ItemDetails.Models.Containers;
using GW2DotNET.V1.Core.ItemDetails.Models.CraftingMaterials;
using GW2DotNET.V1.Core.ItemDetails.Models.GatheringEquipment;
using GW2DotNET.V1.Core.ItemDetails.Models.Gizmos;
using GW2DotNET.V1.Core.ItemDetails.Models.MiniPets;
using GW2DotNET.V1.Core.ItemDetails.Models.Tools;
using GW2DotNET.V1.Core.ItemDetails.Models.Trinkets;
using GW2DotNET.V1.Core.ItemDetails.Models.Trophies;
using GW2DotNET.V1.Core.ItemDetails.Models.UpgradeComponents;
using GW2DotNET.V1.Core.ItemDetails.Models.Weapons;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GW2DotNET.V1.Core.ItemDetails
{
    /// <summary>
    /// Converts a JSON object that describes an item's details to and from an <see cref="ItemDetailsResponse"/>.
    /// </summary>
    public class ItemDetailsResponseConverter : JsonConverter
    {
        /// <summary>
        /// Backing field. Holds a dictionary of in-game item types and their corresponding .NET class.
        /// </summary>
        private static readonly IDictionary<ItemType, Type> ItemTypes = new Dictionary<ItemType, Type>();

        /// <summary>
        /// Initializes static members of the <see cref="ItemDetailsResponseConverter"/> class.
        /// </summary>
        static ItemDetailsResponseConverter()
        {
            ItemTypes.Add(ItemType.Armor, typeof(Armor));
            ItemTypes.Add(ItemType.Back, typeof(Back));
            ItemTypes.Add(ItemType.Bag, typeof(Bag));
            ItemTypes.Add(ItemType.Consumable, typeof(Consumable));
            ItemTypes.Add(ItemType.Container, typeof(Container));
            ItemTypes.Add(ItemType.CraftingMaterial, typeof(CraftingMaterial));
            ItemTypes.Add(ItemType.Gathering, typeof(Gathering));
            ItemTypes.Add(ItemType.Gizmo, typeof(Gizmo));
            ItemTypes.Add(ItemType.MiniPet, typeof(MiniPet));
            ItemTypes.Add(ItemType.Tool, typeof(Tool));
            ItemTypes.Add(ItemType.Trinket, typeof(Trinket));
            ItemTypes.Add(ItemType.Trophy, typeof(Trophy));
            ItemTypes.Add(ItemType.UpgradeComponent, typeof(UpgradeComponent));
            ItemTypes.Add(ItemType.Weapon, typeof(Weapon));
        }

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>Returns <c>true</c> if this instance can convert the specified object type; otherwise <c>false</c>.</returns>
        public override bool CanConvert(Type objectType)
        {
            return typeof(ItemDetailsResponse).IsAssignableFrom(objectType);
        }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="JsonReader"/> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jsonObject = JObject.Load(reader);
            string jsonValue = (string)jsonObject["type"];
            ItemType itemType;
            if (!Enum.TryParse<ItemType>(jsonValue, out itemType))
            {
                throw new JsonSerializationException("Unknown item type: " + jsonValue);
            }

            Type concreteType;

            if (!ItemTypes.TryGetValue(itemType, out concreteType))
            {
                throw new JsonSerializationException(string.Format("Item type '{0}' is not supported", itemType.ToString()));
            }

            Item itemDetails = (Item)serializer.Deserialize(jsonObject.CreateReader(), concreteType);
            return new ItemDetailsResponse(itemDetails);
        }

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, ((ItemDetailsResponse)value).ItemDetails);
        }
    }
}