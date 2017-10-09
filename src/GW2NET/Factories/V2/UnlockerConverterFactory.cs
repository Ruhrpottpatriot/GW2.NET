// <copyright file="UnlockerConverterFactory.cs" company="GW2.NET Coding Team">
// This product is licensed under the GNU General Public License version 2 (GPLv2). See the License in the project root folder or the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>

namespace GW2NET.Factories.V2
{
    using System.Diagnostics;
    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V2.Items.Converters;
    using GW2NET.V2.Items.Json;

    public class UnlockerConverterFactory : ITypeConverterFactory<ItemDTO, Unlocker>
    {
        public IConverter<ItemDTO, Unlocker> Create(string discriminator)
        {
            switch (discriminator)
            {
                case "BagSlot":
                    return new BagSlotUnlockerConverter();
                case "BankTab":
                    return new BankTabUnlockerConverter();
                case "CollectibleCapacity":
                    return new CollectibleCapacityUnlockerConverter();
                case "Content":
                    return new ContentUnlockerConverter();
                case "CraftingRecipe":
                    return new CraftingRecipeUnlockerConverter();
                case "Dye":
                    return new DyeUnlockerConverter();
                case "Outfit":
                    return new OutfitUnlockerConverter();
                case "GliderSkin":
                    return new GliderSkinUnlockerConverter();
                case "Champion":
                    return new ChampionUnlockerConverter();
                default:
                    Debug.Assert(false, "Unknown type discriminator: " + discriminator);
                    return new UnknownUnlockerConverter();
            }
        }
    }
}