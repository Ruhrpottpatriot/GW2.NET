// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RecipeConfiguration.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The recipe configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.Persistence.Configuration
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    using GW2DotNET.V1.Recipes.Details.Contracts;

    /// <summary>The recipe configuration.</summary>
    public class RecipeConfiguration : EntityTypeConfiguration<Recipe>
    {
        /// <summary>Initializes a new instance of the <see cref="RecipeConfiguration"/> class.</summary>
        public RecipeConfiguration()
        {
            this.HasKey(recipe => new { recipe.RecipeId, recipe.Language });
            this.Property(recipe => recipe.RecipeId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            this.HasMany(recipe => recipe.Ingredients).WithMany();
            this.HasRequired(recipe => recipe.OutputItem)
                .WithMany()
                .HasForeignKey(recipe => new { recipe.OutputItemId, recipe.Language })
                .WillCascadeOnDelete(false);
        }
    }
}