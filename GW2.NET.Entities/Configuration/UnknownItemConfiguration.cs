// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnknownItemConfiguration.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The unknown item configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.Entities.Configuration
{
    using System.Data.Entity.ModelConfiguration;

    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes;

    /// <summary>The unknown item configuration.</summary>
    public class UnknownItemConfiguration : EntityTypeConfiguration<UnknownItem>
    {
        /// <summary>Initializes a new instance of the <see cref="UnknownItemConfiguration" /> class.</summary>
        public UnknownItemConfiguration()
        {
            const string TableName = "UnknownItems";
            this.ToTable(TableName);
        }
    }
}