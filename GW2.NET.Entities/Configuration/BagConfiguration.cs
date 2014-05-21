// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BagConfiguration.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The bag configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.Entities.Configuration
{
    using System.Data.Entity.ModelConfiguration;

    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Bags;

    /// <summary>The bag configuration.</summary>
    public class BagConfiguration : EntityTypeConfiguration<Bag>
    {
        /// <summary>Initializes a new instance of the <see cref="BagConfiguration" /> class.</summary>
        public BagConfiguration()
        {
            const string TableName = "Bags";
            this.ToTable(TableName);
        }
    }
}