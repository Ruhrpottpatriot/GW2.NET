// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CraftingMaterialConfiguration.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The crafting material configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.Entities.Configuration
{
    using System.Data.Entity.ModelConfiguration;

    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.CraftingMaterials;

    /// <summary>The crafting material configuration.</summary>
    public class CraftingMaterialConfiguration : EntityTypeConfiguration<CraftingMaterial>
    {
        /// <summary>Initializes a new instance of the <see cref="CraftingMaterialConfiguration" /> class.</summary>
        public CraftingMaterialConfiguration()
        {
            const string TableName = "CraftingMaterials";
            this.ToTable(TableName);
        }
    }
}