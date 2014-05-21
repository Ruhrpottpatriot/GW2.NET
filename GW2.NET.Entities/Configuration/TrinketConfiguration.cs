// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TrinketConfiguration.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The trinket configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.Entities.Configuration
{
    using System.Data.Entity.ModelConfiguration;

    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Trinkets;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Trinkets.TrinketTypes;

    /// <summary>
    /// The trinket configuration.
    /// </summary>
    public class TrinketConfiguration : EntityTypeConfiguration<Trinket>
    {
        /// <summary>The table name.</summary>
        private const string TableName = "Trinkets";

        /// <summary>Initializes a new instance of the <see cref="TrinketConfiguration" /> class.</summary>
        public TrinketConfiguration()
        {
            var discriminator = typeof(TrinketType).Name;
            this.Map<UnknownTrinket>(config => config.Requires(discriminator).HasValue((int)TrinketType.Unknown))
                .Map<Accessory>(config => config.Requires(discriminator).HasValue((int)TrinketType.Accessory))
                .Map<Amulet>(config => config.Requires(discriminator).HasValue((int)TrinketType.Amulet))
                .Map<Ring>(config => config.Requires(discriminator).HasValue((int)TrinketType.Ring))
                .ToTable(TableName);
            this.HasMany(item => item.Attributes).WithMany();
        }
    }
}