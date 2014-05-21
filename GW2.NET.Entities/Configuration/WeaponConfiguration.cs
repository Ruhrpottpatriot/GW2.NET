// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WeaponConfiguration.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The weapon configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.Entities.Configuration
{
    using System.Data.Entity.ModelConfiguration;

    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Weapons;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Weapons.WeaponTypes;

    /// <summary>
    /// The weapon configuration.
    /// </summary>
    public class WeaponConfiguration : EntityTypeConfiguration<Weapon>
    {
        /// <summary>The table name.</summary>
        private const string TableName = "Weapons";

        /// <summary>Initializes a new instance of the <see cref="WeaponConfiguration" /> class.</summary>
        public WeaponConfiguration()
        {
            var discriminator = typeof(WeaponType).Name;
            this.Map<UnknownWeapon>(config => config.Requires(discriminator).HasValue((int)WeaponType.Unknown))
                .Map<Axe>(config => config.Requires(discriminator).HasValue((int)WeaponType.Axe))
                .Map<Dagger>(config => config.Requires(discriminator).HasValue((int)WeaponType.Dagger))
                .Map<Focus>(config => config.Requires(discriminator).HasValue((int)WeaponType.Focus))
                .Map<GreatSword>(config => config.Requires(discriminator).HasValue((int)WeaponType.GreatSword))
                .Map<Hammer>(config => config.Requires(discriminator).HasValue((int)WeaponType.Hammer))
                .Map<Harpoon>(config => config.Requires(discriminator).HasValue((int)WeaponType.Harpoon))
                .Map<LargeBundle>(config => config.Requires(discriminator).HasValue((int)WeaponType.LargeBundle))
                .Map<LongBow>(config => config.Requires(discriminator).HasValue((int)WeaponType.LongBow))
                .Map<Mace>(config => config.Requires(discriminator).HasValue((int)WeaponType.Mace))
                .Map<Pistol>(config => config.Requires(discriminator).HasValue((int)WeaponType.Pistol))
                .Map<Rifle>(config => config.Requires(discriminator).HasValue((int)WeaponType.Rifle))
                .Map<Scepter>(config => config.Requires(discriminator).HasValue((int)WeaponType.Scepter))
                .Map<Shield>(config => config.Requires(discriminator).HasValue((int)WeaponType.Shield))
                .Map<ShortBow>(config => config.Requires(discriminator).HasValue((int)WeaponType.ShortBow))
                .Map<SpearGun>(config => config.Requires(discriminator).HasValue((int)WeaponType.SpearGun))
                .Map<Staff>(config => config.Requires(discriminator).HasValue((int)WeaponType.Staff))
                .Map<Sword>(config => config.Requires(discriminator).HasValue((int)WeaponType.Sword))
                .Map<Torch>(config => config.Requires(discriminator).HasValue((int)WeaponType.Torch))
                .Map<ToyWeapon>(config => config.Requires(discriminator).HasValue((int)WeaponType.Toy))
                .Map<Trident>(config => config.Requires(discriminator).HasValue((int)WeaponType.Trident))
                .Map<TwoHandedToyWeapon>(config => config.Requires(discriminator).HasValue((int)WeaponType.TwoHandedToy))
                .Map<WarHorn>(config => config.Requires(discriminator).HasValue((int)WeaponType.Warhorn))
                .ToTable(TableName);
            this.HasMany(item => item.Attributes).WithMany();
        }
    }
}