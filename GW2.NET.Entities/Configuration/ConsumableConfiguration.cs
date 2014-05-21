// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsumableConfiguration.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The consumable configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.Entities.Configuration
{
    using System.Data.Entity.ModelConfiguration;

    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Consumables;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Consumables.ConsumableTypes;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Consumables.ConsumableTypes.UnlockTypes;

    /// <summary>The consumable configuration.</summary>
    public class ConsumableConfiguration : EntityTypeConfiguration<Consumable>
    {
        /// <summary>The table name.</summary>
        private const string TableName = "Consumables";

        /// <summary>Initializes a new instance of the <see cref="ConsumableConfiguration"/> class.</summary>
        public ConsumableConfiguration()
        {
            var discriminator = typeof(ConsumableType).Name;

            this.Map<UnknownConsumable>(config => config.Requires(discriminator).HasValue((int)ConsumableType.Unknown))
                .Map<AppearanceChanger>(config => config.Requires(discriminator).HasValue((int)ConsumableType.AppearanceChange))
                .Map<Booze>(config => config.Requires(discriminator).HasValue((int)ConsumableType.Booze))
                .Map<ContractNpc>(config => config.Requires(discriminator).HasValue((int)ConsumableType.ContractNpc))
                .Map<Food>(config => config.Requires(discriminator).HasValue((int)ConsumableType.Food))
                .Map<GenericConsumable>(config => config.Requires(discriminator).HasValue((int)ConsumableType.Generic))
                .Map<HalloweenConsumable>(config => config.Requires(discriminator).HasValue((int)ConsumableType.Halloween))
                .Map<ImmediateConsumable>(config => config.Requires(discriminator).HasValue((int)ConsumableType.Immediate))
                .Map<Transmutation>(config => config.Requires(discriminator).HasValue((int)ConsumableType.Transmutation))
                .Map<UnTransmutation>(config => config.Requires(discriminator).HasValue((int)ConsumableType.UnTransmutation))
                .Map<UpgradeRemoval>(config => config.Requires(discriminator).HasValue((int)ConsumableType.UpgradeRemoval))
                .Map<Utility>(config => config.Requires(discriminator).HasValue((int)ConsumableType.Utility))
                .Map<UnknownUnlocker>(config => config.Requires(discriminator).HasValue((int)ConsumableType.Unlock | (int)UnlockType.Unknown))
                .Map<BagSlotUnlocker>(config => config.Requires(discriminator).HasValue((int)ConsumableType.Unlock | (int)UnlockType.BagSlot))
                .Map<BankTabUnlocker>(config => config.Requires(discriminator).HasValue((int)ConsumableType.Unlock | (int)UnlockType.BankTab))
                .Map<CollectibleCapacityUnlocker>(
                    config => config.Requires(discriminator).HasValue((int)ConsumableType.Unlock | (int)UnlockType.CollectibleCapacity))
                .Map<ContentUnlocker>(config => config.Requires(discriminator).HasValue((int)ConsumableType.Unlock | (int)UnlockType.Content))
                .Map<CraftingRecipeUnlocker>(config => config.Requires(discriminator).HasValue((int)ConsumableType.Unlock | (int)UnlockType.CraftingRecipe))
                .Map<DyeUnlocker>(config => config.Requires(discriminator).HasValue((int)ConsumableType.Unlock | (int)UnlockType.Dye))
                .ToTable(TableName);
        }
    }
}