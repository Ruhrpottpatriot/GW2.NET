// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MiniPetConfiguration.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The mini pet configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.Entities.Configuration
{
    using System.Data.Entity.ModelConfiguration;

    using GW2DotNET.V1.Items.Details.Contracts.ItemTypes.MiniPets;

    /// <summary>The mini pet configuration.</summary>
    public class MiniPetConfiguration : EntityTypeConfiguration<MiniPet>
    {
        /// <summary>Initializes a new instance of the <see cref="MiniPetConfiguration" /> class.</summary>
        public MiniPetConfiguration()
        {
            const string TableName = "MiniPets";
            this.ToTable(TableName);
        }
    }
}