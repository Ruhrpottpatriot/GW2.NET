// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemAttributeConfiguration.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The item attribute configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.Entities.Configuration
{
    using System.Data.Entity.ModelConfiguration;

    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.Common;

    /// <summary>
    /// The item attribute configuration.
    /// </summary>
    public class ItemAttributeConfiguration : EntityTypeConfiguration<ItemAttribute>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemAttributeConfiguration"/> class.
        /// </summary>
        public ItemAttributeConfiguration()
        {
            this.HasKey(attribute => new { attribute.Type, attribute.Modifier });
        }
    }
}