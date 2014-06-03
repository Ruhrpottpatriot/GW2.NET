// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemConfiguration.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The item configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.Persistence.Configuration
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    using GW2DotNET.V1.Items.Details.Contracts;

    /// <summary>The item configuration.</summary>
    public class ItemConfiguration : EntityTypeConfiguration<Item>
    {
        /// <summary>Initializes a new instance of the <see cref="ItemConfiguration"/> class.</summary>
        public ItemConfiguration()
        {
            this.HasKey(item => new { item.ItemId, item.Language });
            this.Property(item => item.ItemId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            this.HasRequired(item => item.Build).WithMany().HasForeignKey(item => item.BuildId);
        }
    }
}