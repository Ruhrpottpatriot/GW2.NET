// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BackConfiguration.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The back configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.Entities.Configuration
{
    using System.Data.Entity.ModelConfiguration;

    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Backs;

    /// <summary>The back configuration.</summary>
    public class BackConfiguration : EntityTypeConfiguration<Back>
    {
        /// <summary>Initializes a new instance of the <see cref="BackConfiguration" /> class.</summary>
        public BackConfiguration()
        {
            const string TableName = "Backs";
            this.ToTable(TableName);
            this.HasMany(item => item.Attributes).WithMany();
        }
    }
}