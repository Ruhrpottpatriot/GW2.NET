// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ToolConfiguration.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The tool configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.Entities.Configuration
{
    using System.Data.Entity.ModelConfiguration;

    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Tools;
    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Tools.ToolTypes;

    /// <summary>The tool configuration.</summary>
    public class ToolConfiguration : EntityTypeConfiguration<Tool>
    {
        /// <summary>The table name.</summary>
        private const string TableName = "Tools";

        /// <summary>Initializes a new instance of the <see cref="ToolConfiguration"/> class.</summary>
        public ToolConfiguration()
        {
            var discriminator = typeof(ToolType).Name;
            this.Map<SalvageTool>(config => config.Requires(discriminator).HasValue((int)ToolType.Salvage))
                .Map<UnknownTool>(config => config.Requires(discriminator).HasValue((int)ToolType.Unknown))
                .ToTable(TableName);
        }
    }
}