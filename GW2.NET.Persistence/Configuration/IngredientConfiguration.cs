// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IngredientConfiguration.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The portion configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.Persistence.Configuration
{
    using System.Data.Entity.ModelConfiguration;

    using GW2DotNET.V1.Recipes.Details.Contracts;

    /// <summary>The portion configuration.</summary>
    public class IngredientConfiguration : EntityTypeConfiguration<Ingredient>
    {
        /// <summary>Initializes a new instance of the <see cref="IngredientConfiguration"/> class.</summary>
        public IngredientConfiguration()
        {
            this.HasKey(ingredient => new { ingredient.ItemId, ingredient.Language, ingredient.Count });
            this.HasRequired(ingredient => ingredient.Item)
                .WithMany()
                .HasForeignKey(ingredient => new { ingredient.ItemId, ingredient.Language })
                .WillCascadeOnDelete(false);
        }
    }
}