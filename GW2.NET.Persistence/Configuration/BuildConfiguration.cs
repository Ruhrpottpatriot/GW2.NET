// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BuildConfiguration.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The build configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.Persistence.Configuration
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    using GW2DotNET.V1.Builds.Contracts;

    /// <summary>The build configuration.</summary>
    public class BuildConfiguration : EntityTypeConfiguration<Build>
    {
        /// <summary>Initializes a new instance of the <see cref="BuildConfiguration"/> class.</summary>
        public BuildConfiguration()
        {
            this.Property(entity => entity.BuildId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}