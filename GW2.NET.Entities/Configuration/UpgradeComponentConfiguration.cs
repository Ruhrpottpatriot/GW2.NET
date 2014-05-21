// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpgradeComponentConfiguration.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The upgrade component configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.Entities.Configuration
{
    using System.Data.Entity.ModelConfiguration;

    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.UpgradeComponents;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.UpgradeComponents.UpgradeComponentTypes;

    /// <summary>
    /// The upgrade component configuration.
    /// </summary>
    public class UpgradeComponentConfiguration : EntityTypeConfiguration<UpgradeComponent>
    {
        /// <summary>The table name.</summary>
        private const string TableName = "UpgradeComponents";

        /// <summary>Initializes a new instance of the <see cref="UpgradeComponentConfiguration" /> class.</summary>
        public UpgradeComponentConfiguration()
        {
            var discriminator = typeof(UpgradeComponentType).Name;
            this.Map<UnknownUpgradeComponent>(config => config.Requires(discriminator).HasValue((int)UpgradeComponentType.Unknown))
                .Map<DefaultUpgradeComponent>(config => config.Requires(discriminator).HasValue((int)UpgradeComponentType.Default))
                .Map<Gem>(config => config.Requires(discriminator).HasValue((int)UpgradeComponentType.Gem))
                .Map<Rune>(config => config.Requires(discriminator).HasValue((int)UpgradeComponentType.Rune))
                .Map<Sigil>(config => config.Requires(discriminator).HasValue((int)UpgradeComponentType.Sigil))
                .ToTable(TableName);
            this.HasMany(item => item.Attributes).WithMany();
        }
    }
}