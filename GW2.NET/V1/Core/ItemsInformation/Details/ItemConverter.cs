// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemConverter.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using GW2DotNET.V1.Core.Converters;
using GW2DotNET.V1.Core.ItemsInformation.Details.Items;
using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Armors;
using GW2DotNET.V1.Core.ItemsInformation.Details.Items.BackPieces;
using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Bags;
using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Consumables;
using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Containers;
using GW2DotNET.V1.Core.ItemsInformation.Details.Items.CraftingMaterials;
using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Gathering;
using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Gizmos;
using GW2DotNET.V1.Core.ItemsInformation.Details.Items.MiniPets;
using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Tools;
using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Trinkets;
using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Trophies;
using GW2DotNET.V1.Core.ItemsInformation.Details.Items.UpgradeComponents;
using GW2DotNET.V1.Core.ItemsInformation.Details.Items.Weapons;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GW2DotNET.V1.Core.ItemsInformation.Details
{
    /// <summary>
    /// Converts an instance of a class that extends <see cref="Item"/> from its <see cref="System.String"/> representation.
    /// </summary>
    public class ItemConverter : ContentBasedTypeCreationConverter
    {
        /// <summary>
        /// Backing field. Holds a dictionary of known JSON values and their corresponding type.
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
            KnownTypes.Add(ItemType.Gathering, typeof(GatheringTool));
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
        /// <param name="objectType">ToolType of the object.</param>
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
            if (content["type"] == null)
            {
                throw new JsonSerializationException(content.ToObject<ErrorResponse>().Text);
            }

            var jsonValue = JsonSerializer.Create().Deserialize<ItemType>(content["type"].CreateReader());

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