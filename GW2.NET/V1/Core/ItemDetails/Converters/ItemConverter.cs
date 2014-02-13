// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemConverter.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using GW2DotNET.V1.Core.Converters;
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

namespace GW2DotNET.V1.Core.ItemDetails.Converters
{
    /// <summary>
    /// Converts an <see cref="Item"/> to and from its <see cref="System.String"/> representation.
    /// </summary>
    public class ItemConverter : ContentBasedTypeCreationConverter<Item>
    {
        /// <summary>
        /// Backing field. Holds a dictionary of in-game item types and their corresponding .NET class.
        /// </summary>
        private static readonly IDictionary<ItemType, Type> ItemTypes = new Dictionary<ItemType, Type>();

        /// <summary>
        /// Initializes static members of the <see cref="ItemConverter"/> class.
        /// </summary>
        static ItemConverter()
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
            return ItemTypes.Values.Contains(objectType);
        }

        /// <summary>
        /// Gets the object type that will be used by the serializer.
        /// </summary>
        /// <param name="objectType">The type of the object.</param>
        /// <param name="content">The JSON content.</param>
        /// <returns>Returns the target type.</returns>
        public override Type GetTargetType(Type objectType, JObject content)
        {
            JsonReader typeReader = content["type"].CreateReader();

            ItemType jsonValue = JsonSerializer.Create().Deserialize<ItemType>(typeReader);

            Type itemType;

            if (!ItemTypes.TryGetValue(jsonValue, out itemType))
            {
                throw new JsonSerializationException("Unknown item type: " + jsonValue);
            }

            return itemType;
        }
    }
}