// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GatheringToolConfiguration.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The gathering tool configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.Entities.Configuration
{
    using System.Data.Entity.ModelConfiguration;

    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.GatheringTools;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.GatheringTools.GatheringToolsTypes;

    /// <summary>
    /// The gathering tool configuration.
    /// </summary>
    public class GatheringToolConfiguration : EntityTypeConfiguration<GatheringTool>
    {
        /// <summary>The table name.</summary>
        private const string TableName = "GatheringTools";

        /// <summary>Initializes a new instance of the <see cref="GatheringToolConfiguration" /> class.</summary>
        public GatheringToolConfiguration()
        {
            var discriminator = typeof(GatheringToolType).Name;
            this.Map<UnknownGatheringTool>(config => config.Requires(discriminator).HasValue((int)GatheringToolType.Unknown))
                .Map<ForagingTool>(config => config.Requires(discriminator).HasValue((int)GatheringToolType.Foraging))
                .Map<LoggingTool>(config => config.Requires(discriminator).HasValue((int)GatheringToolType.Logging))
                .Map<MiningTool>(config => config.Requires(discriminator).HasValue((int)GatheringToolType.Mining))
                .ToTable(TableName);
        }
    }
}