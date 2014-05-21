// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TrophyConfiguration.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The trophy configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.Entities.Configuration
{
    using System.Data.Entity.ModelConfiguration;

    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Trophies;

    /// <summary>The trophy configuration.</summary>
    public class TrophyConfiguration : EntityTypeConfiguration<Trophy>
    {
        /// <summary>Initializes a new instance of the <see cref="TrophyConfiguration" /> class.</summary>
        public TrophyConfiguration()
        {
            const string TableName = "Trophies";
            this.ToTable(TableName);
        }
    }
}