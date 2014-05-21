// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArmorConfiguration.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The armor configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.Entities.Configuration
{
    using System.Data.Entity.ModelConfiguration;

    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Armors;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Armors.ArmorTypes;

    /// <summary>The armor configuration.</summary>
    public class ArmorConfiguration : EntityTypeConfiguration<Armor>
    {
        /// <summary>The table name.</summary>
        private const string TableName = "Armors";

        /// <summary>Initializes a new instance of the <see cref="ArmorConfiguration" /> class.</summary>
        public ArmorConfiguration()
        {
            var discriminator = typeof(ArmorType).Name;
            this.Map<UnknownArmor>(config => config.Requires(discriminator).HasValue((int)ArmorType.Unknown))
                .Map<Boots>(config => config.Requires(discriminator).HasValue((int)ArmorType.Boots))
                .Map<Coat>(config => config.Requires(discriminator).HasValue((int)ArmorType.Coat))
                .Map<Gloves>(config => config.Requires(discriminator).HasValue((int)ArmorType.Gloves))
                .Map<Helm>(config => config.Requires(discriminator).HasValue((int)ArmorType.Helm))
                .Map<AquaticHelm>(config => config.Requires(discriminator).HasValue((int)ArmorType.HelmAquatic))
                .Map<Leggings>(config => config.Requires(discriminator).HasValue((int)ArmorType.Leggings))
                .Map<Shoulders>(config => config.Requires(discriminator).HasValue((int)ArmorType.Shoulders))
                .ToTable(TableName);

            this.HasMany(item => item.Attributes).WithMany();
        }
    }
}