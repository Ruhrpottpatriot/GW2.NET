// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EquipmentConfiguration.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The equipment configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.Persistence.Configuration
{
    using System.Data.Entity.ModelConfiguration;

    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Common;

    /// <summary>The equipment configuration.</summary>
    public class EquipmentConfiguration : EntityTypeConfiguration<CombatItem>
    {
        /// <summary>Initializes a new instance of the <see cref="EquipmentConfiguration"/> class.</summary>
        public EquipmentConfiguration()
        {
            this.HasMany(item => item.Attributes).WithMany();
        }
    }
}