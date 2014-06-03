// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts an instance of a class that extends <see cref="Item" /> from its <see cref="System.String" />
//   representation.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.Items.Details.Contracts
{
    using System;
    using System.Collections.Generic;

    using GW2DotNET.V1.Common.Converters;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Armors;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Backpacks;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Bags;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Consumables;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Containers;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.CraftingMaterials;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.GatheringTools;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Gizmos;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.MiniPets;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Tools;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Trinkets;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Trophies;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.UpgradeComponents;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Weapons;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>Converts an instance of a class that extends <see cref="Item" /> from its <see cref="System.String" />
    /// representation.</summary>
    public class ItemConverter : ContentBasedTypeCreationConverter
    {
        /// <summary>Backing field. Holds a dictionary of known JSON values and their corresponding type.</summary>
        private static readonly IDictionary<ItemType, Type> KnownTypes = new Dictionary<ItemType, Type>();

        /// <summary>Initializes static members of the <see cref="ItemConverter" /> class.</summary>
        static ItemConverter()
        {
            KnownTypes.Add(ItemType.Unknown, typeof(UnknownItem));
            KnownTypes.Add(ItemType.Armor, typeof(Armor));
            KnownTypes.Add(ItemType.Back, typeof(Backpack));
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

        /// <summary>Determines whether this instance can convert the specified object type.</summary>
        /// <param name="objectType">ToolType of the object.</param>
        /// <returns>Returns <c>true</c> if this instance can convert the specified object type; otherwise <c>false</c>.</returns>
        public override bool CanConvert(Type objectType)
        {
            return KnownTypes.Values.Contains(objectType);
        }

        /// <summary>Gets the object type that will be used by the serializer.</summary>
        /// <param name="objectType">The type of the object.</param>
        /// <param name="content">The JSON content.</param>
        /// <returns>Returns the target type.</returns>
        protected override Type GetTargetType(Type objectType, JObject content)
        {
            var jsonToken = content["type"];

            if (jsonToken == null)
            {
                return typeof(UnknownItem);
            }

            var jsonValue = jsonToken.Value<string>();

            try
            {
                ItemType type;

                if (!Enum.TryParse(jsonValue, true, out type))
                {
                    type = JsonSerializer.Create().Deserialize<ItemType>(jsonToken.CreateReader());
                }

                Type targetType;

                if (!KnownTypes.TryGetValue(type, out targetType))
                {
                    return typeof(UnknownItem);
                }

                return targetType;
            }
            catch (JsonSerializationException)
            {
                return typeof(UnknownItem);
            }
            finally
            {
                content.Remove("type");
            }
        }
    }
}