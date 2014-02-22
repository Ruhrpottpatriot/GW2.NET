// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemConverter.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using GW2DotNET.V1.Core.Converters;
using GW2DotNET.V1.Core.ItemsInformation.Details.ArmorPieces;
using GW2DotNET.V1.Core.ItemsInformation.Details.BackPieces;
using GW2DotNET.V1.Core.ItemsInformation.Details.Bags;
using GW2DotNET.V1.Core.ItemsInformation.Details.Common;
using GW2DotNET.V1.Core.ItemsInformation.Details.Consumables;
using GW2DotNET.V1.Core.ItemsInformation.Details.Containers;
using GW2DotNET.V1.Core.ItemsInformation.Details.CraftingMaterials;
using GW2DotNET.V1.Core.ItemsInformation.Details.GatheringEquipment;
using GW2DotNET.V1.Core.ItemsInformation.Details.Gizmos;
using GW2DotNET.V1.Core.ItemsInformation.Details.MiniPets;
using GW2DotNET.V1.Core.ItemsInformation.Details.Tools;
using GW2DotNET.V1.Core.ItemsInformation.Details.Trinkets;
using GW2DotNET.V1.Core.ItemsInformation.Details.Trophies;
using GW2DotNET.V1.Core.ItemsInformation.Details.UpgradeComponents;
using GW2DotNET.V1.Core.ItemsInformation.Details.Weapons;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GW2DotNET.V1.Core.ItemsInformation.Converters
{
    /// <summary>
    /// Converts an <see cref="Item"/> to and from its <see cref="System.String"/> representation.
    /// </summary>
    public class ItemConverter : ContentBasedTypeCreationConverter
    {
        /// <summary>
        /// Backing field. Holds a dictionary of in-game item types and their corresponding .NET class.
        /// </summary>
        private static readonly IDictionary<ItemType, Type> KnownTypes = new Dictionary<ItemType, Type>();

        /// <summary>
        /// Initializes static members of the <see cref="ItemConverter"/> class.
        /// </summary>
        static ItemConverter()
        {
            KnownTypes.Add(ItemType.Armor, typeof(Armor));
            KnownTypes.Add(ItemType.Back, typeof(Back));
            KnownTypes.Add(ItemType.Bag, typeof(Bag));
            KnownTypes.Add(ItemType.Consumable, typeof(Consumable));
            KnownTypes.Add(ItemType.Container, typeof(Container));
            KnownTypes.Add(ItemType.CraftingMaterial, typeof(CraftingMaterial));
            KnownTypes.Add(ItemType.Gathering, typeof(Gathering));
            KnownTypes.Add(ItemType.Gizmo, typeof(Gizmo));
            KnownTypes.Add(ItemType.MiniPet, typeof(MiniPet));
            KnownTypes.Add(ItemType.Tool, typeof(Tool));
            KnownTypes.Add(ItemType.Trinket, typeof(Trinket));
            KnownTypes.Add(ItemType.Trophy, typeof(Trophy));
            KnownTypes.Add(ItemType.UpgradeComponent, typeof(UpgradeComponent));
            KnownTypes.Add(ItemType.Weapon, typeof(Weapon));
        }

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>Returns <c>true</c> if this instance can convert the specified object type; otherwise <c>false</c>.</returns>
        public override bool CanConvert(Type objectType)
        {
            return KnownTypes.Values.Contains(objectType);
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

            var jsonValue = JsonSerializer.Create().Deserialize<ItemType>(typeReader);

            Type targetType;

            if (!KnownTypes.TryGetValue(jsonValue, out targetType))
            {
                // TODO: consider introducing an UnknownItem class and enum value
                throw new JsonSerializationException("Unknown item type: " + jsonValue);
            }

            return targetType;
        }
    }
}